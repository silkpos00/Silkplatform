using Microsoft.Data.SqlClient;
using Dapper;

namespace CoreApi.Model.BackOffice
{
    public class BackOfficeRepository
    {
        private readonly IConfiguration _config;
        private readonly string? _connectionString;


        public BackOfficeRepository(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = configuration.GetConnectionString("cnn");

        }
        public async Task<dynamic?> GetUserMenuDataAsync(int PortalID,int UserID)
        {
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_MenuData @PortalID,@UserID";
            var _data = await conn.QueryAsync<dynamic>(query, new { PortalID,UserID });
            return _data;
        }
    }
}
