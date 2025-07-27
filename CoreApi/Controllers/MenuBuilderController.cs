using CoreApi.Model;
using CoreApi.Model.MenuBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreApi.Controllers
{
    [EnableCors("PolicySilkpos")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuBuilderController : ControllerBase
    {
        private readonly MenuBulderRepository? _menuBulderRepository;
        public MenuBuilderController(MenuBulderRepository? menuBulderRepository)
        {
            _menuBulderRepository = menuBulderRepository;
        }
        [Authorize]
        [HttpGet("GetMenus")]
        public async Task<dynamic> GetMenus()
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetMenusDataAsync(Convert.ToInt32(portalID));
                return Ok(new ApiResponse<dynamic>
                {
                    Status = true,
                    Message = "The operation was successful.",
                    Data = _data
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new ApiResponse<string>
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
        [Authorize]
        [HttpPost("GetCategory")]
        public async Task<dynamic> GetCategory(GetCategoryParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetCategoryDataAsync(Convert.ToInt32(portalID),p.MenuID,p.AppID);
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
        [HttpPost("GetItemsByCategory")]
        public async Task<dynamic> GetItemsByCategory(GetItemsByCategoryParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetItemsByCategoryDataAsync(Convert.ToInt32(portalID), p.CategoryID,p.ItemSizeID);
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
        [HttpPost("GetItemsPagesByCategory")]
        public async Task<dynamic> GetItemsPagesByCategory(GetItemsPagesByCategoryParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetItemsPagesByCategoryDataAsync(Convert.ToInt32(portalID), p.CategoryID);
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
        [HttpGet("GetModifierCategory")]
        public async Task<dynamic> GetModifierCategory()
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetModifierCategoryDataAsync(Convert.ToInt32(portalID));
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
        [HttpPost("GetModifiersByCategory")]
        public async Task<dynamic> GetModifiersByCategory(GetModifiersByCategoryParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetModifiersByCategoryDataAsync(Convert.ToInt32(portalID), p.CategoryID);
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
        [HttpPost("GetModifiersPagesByCategory")]
        public async Task<dynamic> GetModifiersPagesByCategory(GetModifiersPagesByCategoryParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetModifiersPagesByCategoryDataAsync(Convert.ToInt32(portalID), p.CategoryID);
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
        [HttpPost("GetItemsSize")]
        public async Task<dynamic> GetItemsSize(GetItemsSizeParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetItemsSizeDataAsync(Convert.ToInt32(portalID), p.CategoryID);
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
        [HttpPost("GetItemByID")]
        public async Task<dynamic> GetItemByID(GetItemByIDParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetItemByIDDataAsync(Convert.ToInt32(portalID), p.ItemID);
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
        [HttpPost("AddItem")]
        public async Task<dynamic> AddItem(AddItemParams p)
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var userID = User.FindFirst("UserID")?.Value;
                var _data = await _menuBulderRepository.AddItemDataAsync(Convert.ToInt32(portalID),Convert.ToInt32(userID), p);
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
        [HttpGet("GetModifierSelectMode")]
        public async Task<dynamic> GetModifierSelectMode()
        {
            try
            {
                var portalID = User.FindFirst("PortalID")?.Value;
                var _data = await _menuBulderRepository.GetModifierSelectModeDataAsync(Convert.ToInt32(portalID));
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
