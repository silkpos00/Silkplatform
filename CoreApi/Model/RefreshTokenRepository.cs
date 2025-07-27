using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CoreApi.Model
{
    public class RefreshTokenRepository
    {
        private readonly string _connectionString;

        public RefreshTokenRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("cnn");
        }

        public async Task SaveRefreshTokenAsync(string username, string token, DateTime expiry)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"INSERT INTO RefreshTokens (Id, UserName, Token, ExpiryDate)
              VALUES (@Id, @UserName, @Token, @ExpiryDate)";
            await conn.ExecuteAsync(query, new
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Token = token,
                ExpiryDate = expiry
            });
        }
        public async Task SaveTokenAsync(string username, string token, DateTime expiry,string TokenType)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_TokensGenerateLog @UserName,@Token,@ExpiryDate,@TokenType";
            await conn.ExecuteAsync(query, new
            {
                UserName = username,
                Token = token,
                ExpiryDate = expiry,
                TokenType= TokenType
            });
        }
        public async Task<RefreshTokenData?> GetRefreshTokenAsync(string refreshToken)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"SELECT UserName, Token, ExpiryDate
          FROM RefreshTokens
          WHERE Token = @Token";

            return await conn.QueryFirstOrDefaultAsync<RefreshTokenData>(query, new { Token = refreshToken });
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
