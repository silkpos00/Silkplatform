using Dapper;
using Microsoft.Data.SqlClient;
namespace CoreApi.Model.MenuBuilder
{
    public class MenuBulderRepository
    {
        private readonly IConfiguration _config;
        private readonly string? _connectionString;
     

        public MenuBulderRepository(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = configuration.GetConnectionString("cnn");
           
        }
        public async Task<dynamic?> GetMenusDataAsync(int PortalID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetMenus @PortalID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID });
            return _data;
        }
        public async Task<dynamic?> GetCategoryDataAsync(int PortalID,int MenuID,int AppID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetCategory @PortalID,@MenuID,@AppID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID,MenuID,AppID });
            return _data;
        }
        public async Task<dynamic?> GetItemsByCategoryDataAsync(int PortalID, int CategoryID,int ItemSizeID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetItemsByCategory @PortalID,@CategoryID,@ItemSizeID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, CategoryID,ItemSizeID });
            return _data;
        }
        public async Task<dynamic?> GetItemsPagesByCategoryDataAsync(int PortalID, int CategoryID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetItemsPagesByCategory @PortalID,@CategoryID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, CategoryID });
            return _data;
        }
        public async Task<dynamic?> GetItemByIDDataAsync(int PortalID, int ItemID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetItemByID @PortalID,@ItemID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, ItemID });
            return _data;
        }
        public async Task<dynamic?> GetModifierCategoryDataAsync(int PortalID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetModifierCategory @PortalID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID });
            return _data;
        }
        public async Task<dynamic?> GetModifiersByCategoryDataAsync(int PortalID, int CategoryID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetModifiersByCategory @PortalID,@CategoryID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, CategoryID });
            return _data;
        }
        public async Task<dynamic?> GetModifiersPagesByCategoryDataAsync(int PortalID, int CategoryID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetModifiersPagesByCategory @PortalID,@CategoryID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, CategoryID });
            return _data;
        }
        public async Task<dynamic?> GetItemsSizeDataAsync(int PortalID, int CategoryID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetItemsSize @PortalID,@CategoryID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, CategoryID });
            return _data;
        }
        public async Task<dynamic?> GetModifierSelectModeDataAsync(int PortalID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetModifierSelectMode @PortalID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID });
            return _data;
        }
        public async Task<dynamic?> AddItemDataAsync(int PortalID,int UserID, AddItemParams p)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_AddItem 
                                       @PortalID,
                                        @UserID,
                                        @Title,
                                        @DisplayName,
                                        @GroupID,
                                        @IsActive,
                                        @ItemSizeID,
                                        @ImageFile,
                                        @Price,
                                        @Qty,
                                        @BackgroundColor,
                                        @PrinterID,
                                        @TaxRateValue,
                                        @MinQty,
                                        @OrderSort,
                                        @FamilyID,
                                        @Barcode,
                                        @MinModifier,
                                        @MaxModifier,
                                        @PageNo,
                                        @ModifierGroupID,
                                        @IsWeightRequired,
                                        @ItemNumber,
                                        @KitchenDisplayID,
                                        @FoodStampable,
                                        @UnitName,
                                        @Manufacture,
                                        @SKUCode,
                                        @IncludedModifiers,
                                        @PageNoSort,
                                        @MixAndMatchGroupID,
                                        @isVisable,
                                        @MaxFreeModifiersCount,
                                        @Description";
            var _data = await conn.QueryAsync<dynamic>(query, 
                                                          new {   
                                                                PortalID, 
                                                                UserID,
                                                                p.Title,
                                                                p.DisplayName,
                                                                p.GroupID,
                                                                p.IsActive,
                                                                p.ItemSizeID,
                                                                p.ImageFile,
                                                                p.Price,
                                                                p.Qty,
                                                                p.BackgroundColor,
                                                                p.PrinterID,
                                                                p.TaxRateValue,
                                                                p.MinQty,
                                                                p.OrderSort,
                                                                p.FamilyID,
                                                                p.Barcode,
                                                                p.MinModifier,
                                                                p.MaxModifier,
                                                                p.PageNo,
                                                                p.ModifierGroupID,
                                                                p.IsWeightRequired,
                                                                p.ItemNumber,
                                                                p.KitchenDisplayID,
                                                                p.FoodStampable,
                                                                p.UnitName,
                                                                p.Manufacture,
                                                                p.SKUCode,
                                                                p.IncludedModifiers,
                                                                p.PageNoSort,
                                                                p.MixAndMatchGroupID,
                                                                p.isVisable,
                                                                p.MaxFreeModifiersCount,
                                                                p.Description
                                                          });
            return _data;
        }
    }
}
