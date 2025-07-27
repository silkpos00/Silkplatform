
using Microsoft.Data.SqlClient;
using Dapper;

namespace CoreApi.Model.BaseInfo
{
    
    public class BaseInfoRepository
    {
        private readonly IConfiguration _config;
        private readonly string? _connectionString;


        public BaseInfoRepository(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = configuration.GetConnectionString("cnn");

        }
        public async Task<dynamic?> GetTaxRateDataAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetTaxRate";
            var _data = await conn.QueryAsync<dynamic>(query);
            return _data;
        }
        public async Task<dynamic?> GetWeekDaysDataAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetWeekDays";
            var _data = await conn.QueryAsync<dynamic>(query);
            return _data;
        }
        public async Task<dynamic?> GetKitchenDisplaysDataAsync(int PortalID, int KitchenDisplayGroupID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetKitchenDisplays @PortalID,@KitchenDisplayGroupID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, KitchenDisplayGroupID});
            return _data;
        }
        public async Task<dynamic?> GetPrintersDataAsync(int PortalID, int PrinterGroupID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetPrinters @PortalID,@PrinterGroupID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, PrinterGroupID });
            return _data;
        }

        public async Task<dynamic?> GetStationDataAsync(int PortalID, string StationIP)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetStation @PortalID,@StationIP";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID, StationIP });
            return _data;
        }
        public async Task<dynamic?> GetPortalDataAsync(int PortalID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetPortalData @PortalID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID });
            return _data;
        }
    }
}
