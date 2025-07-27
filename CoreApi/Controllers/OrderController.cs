using CoreApi.Model;
using CoreApi.Model.BaseInfo;
using CoreApi.Model.MenuBuilder;
using CoreApi.Model.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CoreApi.Controllers
{
    [EnableCors("PolicySilkpos")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository? _orderRepository;
        public OrderController(OrderRepository? orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [Authorize]
        [HttpPost("GetPrice")]
        public async Task<dynamic> GetPrice(List<ItemParams> p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _orderRepository.GetPriceDataAsync(Convert.ToInt32(portalID), p);
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
        [HttpPost("InsertOrder")]
        public async Task<dynamic> InsertOrder(OrderParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var userID = User.FindFirst("UserID")?.Value;
                var _data = await _orderRepository.InsertOrderDataAsync(p,Convert.ToInt32(portalID), Convert.ToInt32(userID));
                OrderReturnData orderReturnData=new OrderReturnData();
                orderReturnData.orderID = _data;
                return Ok(new ApiResponse<dynamic>
                {
                    Status = true,
                    Message = "The operation was successful.",
                    Data = orderReturnData
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
        [HttpPost("GetOrder")]
        public async Task<dynamic> GetOrder(GetOrderParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var userID = User.FindFirst("UserID")?.Value;
                var _data = await _orderRepository.GetOrderDataAsync(p,Convert.ToInt32(portalID));
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
