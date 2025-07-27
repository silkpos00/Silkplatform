using CoreApi.Model.BackOffice;
using CoreApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApi.Model.BaseInfo;
using CoreApi.Model.MenuBuilder;

namespace CoreApi.Controllers
{
    [EnableCors("PolicySilkpos")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseInfoController : ControllerBase
    {
        private readonly BaseInfoRepository? _baseInfoRepository;
        public BaseInfoController(BaseInfoRepository? baseInfoRepository)
        {
            _baseInfoRepository = baseInfoRepository;
        }
        [Authorize]
        [HttpGet("GetTaxRate")]
        public async Task<dynamic> GetTaxRate()
        {
            try
            {
                var _data = await _baseInfoRepository.GetTaxRateDataAsync();
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
        [Authorize]
        [HttpGet("GetWeekDays")]
        public async Task<dynamic> GetWeekDays()
        {
            try
            {
                var _data = await _baseInfoRepository.GetWeekDaysDataAsync();
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
        [Authorize]
        [HttpPost("GetKitchenDisplays")]
        public async Task<dynamic> GetKitchenDisplays(GetKitchenDisplaysParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _baseInfoRepository.GetKitchenDisplaysDataAsync(Convert.ToInt32(portalID), p.KitchenDisplayGroupID);
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
        [Authorize]
        [HttpPost("GetPrinters")]
        public async Task<dynamic> GetPrinters(GetPrintersParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _baseInfoRepository.GetPrintersDataAsync(Convert.ToInt32(portalID), p.PrinterGroupID);
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
        [Authorize]
        [HttpPost("GetStation")]
        public async Task<dynamic> GetStation(GetStationParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _baseInfoRepository.GetStationDataAsync(Convert.ToInt32(portalID), p.StationIP);
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

        [Authorize]
        [HttpGet("GetPortal")]
        public async Task<dynamic> GetPortal()
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _baseInfoRepository.GetPortalDataAsync(Convert.ToInt32(portalID));
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
