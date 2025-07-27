using CoreApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace CoreApi.Controllers
{
    [EnableCors("PolicySilkpos")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly RefreshTokenRepository _tokenRepo;

        public AuthController(TokenService tokenService, RefreshTokenRepository tokenRepo)
        {
            _tokenService = tokenService;
            _tokenRepo = tokenRepo;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var user = await _tokenService.GetUserDataAsync(request.Username, request.Password);
            if (user == null)
                return StatusCode(401, new ApiResponse<string>
                {
                    Status = false,
                    Message = "User not found or inactive.",
                    Data = null
                });
           // return Unauthorized("User not found or inactive.");
            if (user.Password != request.Password)
                return StatusCode(401, new ApiResponse<string>
                {
                    Status = false,
                    Message = "Incorrect password.",
                    Data = null
                });
           // return Unauthorized("Incorrect password.");
            if (user.UserIsActive==0)
                return StatusCode(401, new ApiResponse<string>
                {
                    Status = false,
                    Message = "User is inactive.",
                    Data = null
                });
            if (user.PortalIsActive == 0)
                return StatusCode(401, new ApiResponse<string>
                {
                    Status = false,
                    Message = "Store is inactive.",
                    Data = null
                });
            //return Unauthorized("User is inactive.");
            var accessToken = await _tokenService.CreateAccessToken(user);
            //var refreshToken = _tokenService.CreateRefreshToken();
            // await _tokenRepo.SaveRefreshTokenAsync(user.UserName, refreshToken, DateTime.UtcNow.AddDays(7));
          
            return Ok(new ApiResponse<dynamic>
            {
                Status = true,
                Message = "The operation was successful.",
                Data = accessToken
            });
        }
        [HttpPost("refresh")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest model)
        {
            if (string.IsNullOrEmpty(model.RefreshToken))
                return BadRequest("Refresh token is required.");

            var tokenData = await _tokenRepo.GetRefreshTokenAsync(model.RefreshToken);

            if (tokenData == null || tokenData.ExpiryDate < DateTime.UtcNow)
                return Unauthorized("Invalid or expired refresh token.");

            // صدور access token جدید
           // var newAccessToken = _tokenService.CreateAccessToken(tokenData.UserName);

            return Ok(new
            {
                //accessToken = newAccessToken
            });
        }
    }
}
