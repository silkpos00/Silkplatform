using CoreApi.Model.MenuBuilder;
using CoreApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApi.Model.BackOffice;
using Microsoft.AspNetCore.Cors;

namespace CoreApi.Controllers
{
    [EnableCors("PolicySilkpos")]
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {
        private readonly BackOfficeRepository? _backOfficeRepository;
        public BackOfficeController(BackOfficeRepository? backOfficeRepository)
        {
            _backOfficeRepository = backOfficeRepository;
        }
        [Authorize]
        [HttpGet("GetUserMenu")]
        public async Task<dynamic> GetUserMenu()
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var userID = User.FindFirst("UserID")?.Value;
                var _data = await _backOfficeRepository.GetUserMenuDataAsync(Convert.ToInt32(portalID), Convert.ToInt32(userID));
                return Ok(new ApiResponse<dynamic>
                {
                    Status = true,
                    Message = "The operation was successful.",
                    Data = _data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}
