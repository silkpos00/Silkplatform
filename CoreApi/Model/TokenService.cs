using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dapper;
namespace CoreApi.Model
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
       
        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = configuration.GetConnectionString("cnn");
        }

        public async Task<string> CreateAccessToken(UserDataModel userData)
        {

            var claims = new[]
            {
             new Claim("UserID", userData.UserID.ToString()),
             new Claim("UserName", userData.UserName),
             new Claim("FullName", userData.FullName),
             new Claim("FirstName", userData.FirstName),
             new Claim("LastName", userData.LastName),            
             new Claim("RoleID",userData.RoleID.ToString()),
             new Claim("RoleName",userData.RoleName),
             new Claim("PortalID", userData.PortalID.ToString())
             //new Claim("PortalTypeID", userData.PortalTypeID.ToString()),
             //new Claim("PortalName", userData.PortalName),
             //new Claim("Address", userData.Address),
             //new Claim("Phone", userData.Phone),
             //new Claim("Zipcode", userData.Zipcode),
             //new Claim("Lat", userData.Lat.ToString()),
             //new Claim("Lon", userData.Lon.ToString()),
             //new Claim("Website", userData.Website),
             // new Claim("Logo", userData.Logo)
            };
            var keyString = _config["Jwt:Key"];
            var keyBytes = Encoding.UTF8.GetBytes(keyString); // باید حداقل 32 بایت باشه
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:AccessTokenExpiryMinutes"]));
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );
            string acssessToken =new JwtSecurityTokenHandler().WriteToken(token);
            await SaveTokenAsync(userData.UserName, acssessToken, expires, "A");
            return acssessToken;
        }
        public async Task SaveTokenAsync(string username, string token, DateTime expiry, string TokenType)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_TokensGenerateLog @UserName,@Token,@ExpiryDate,@TokenType";
            await conn.ExecuteAsync(query, new
            {
                UserName = username,
                Token = token,
                ExpiryDate = expiry,
                TokenType = TokenType
            });
        }
        public string CreateRefreshToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public async Task<UserDataModel?> GetUserDataAsync(string UserName, string Password)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetUserData @UserName,@Password";
            var user = await conn.QueryFirstOrDefaultAsync<UserDataModel>(query, new { UserName, Password });
            return user;
        }
    }
}
