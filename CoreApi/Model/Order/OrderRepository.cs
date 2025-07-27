using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Dynamic;
namespace CoreApi.Model.Order
{
    public class OrderRepository
    {
        private readonly IConfiguration _config;
        private readonly string? _connectionString;


        public OrderRepository(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = configuration.GetConnectionString("cnn");
        }
        public async Task<dynamic?> GetPriceDataAsync(int PortalID, List<ItemParams> p)
        {
            var JsonData = JsonConvert.SerializeObject(p);
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetPrice @JsonData,@PortalID";
            var _data = await conn.QueryFirstOrDefaultAsync<dynamic>(query, new { JsonData, PortalID });
            return _data;
        }
        public async Task<int> InsertOrderDataAsync(OrderParams order, int portalId, int userId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var orderParams = new DynamicParameters();
                        orderParams.Add("@DineNo", order.dineNo);
                        orderParams.Add("@UserID", userId);
                        orderParams.Add("@PortalID", portalId);
                        orderParams.Add("@OrderType", order.orderTypeID);
                        orderParams.Add("@Phone", order.phone);
                        orderParams.Add("@Address", order.address);
                        orderParams.Add("@Name", order.firstName+" "+order.lastName);
                        orderParams.Add("@AptNo", order.aptNo);
                        orderParams.Add("@Zipcode", order.zipcode);
                        orderParams.Add("@Note", order.note);
                        orderParams.Add("@Email", order.email);
                        orderParams.Add("@StationIP", order.stationIP);
                        orderParams.Add("@Lat", order.lat);
                        orderParams.Add("@Lon", order.lon);

                        var orderId = await db.QuerySingleAsync<int>(
                            "sp_NV_InsertOrder",
                            orderParams,
                            commandType: CommandType.StoredProcedure,
                            transaction: transaction
                        );

                        foreach (var check in order.checks)
                        {
                            var checkParams = new DynamicParameters();
                            checkParams.Add("@OrderID", orderId);
                            checkParams.Add("@MasterCheck", check.isMaster);
                            checkParams.Add("@PortalID", portalId);
                            checkParams.Add("@UserID", userId);
                            checkParams.Add("@CheckName", check.checkName);
                            var checkID = await db.QuerySingleAsync<int>(
                                "sp_NV_InsertOrderCheck",
                                checkParams,
                                commandType: CommandType.StoredProcedure,
                                transaction: transaction
                            );

                            foreach (var item in check.items)
                            {
                                var itemParams = new DynamicParameters();
                                itemParams.Add("@OrderID", orderId);
                                itemParams.Add("@CheckID", checkID);
                                itemParams.Add("@ItemID", item.itemID);
                                itemParams.Add("@Qty", item.qty);
                                itemParams.Add("@PortalID", portalId);
                                itemParams.Add("@UserID", userId);
                                itemParams.Add("@Note", item.note);
                                itemParams.Add("@Weight", item.weight);

                                var orderItemID = await db.QuerySingleAsync<int>(
                                    "sp_NV_InsertOrderItem",
                                    itemParams,
                                    commandType: CommandType.StoredProcedure,
                                    transaction: transaction
                                );

                                foreach (var modifier in item.modifiers)
                                {
                                    var modifierParams = new DynamicParameters();
                                    modifierParams.Add("@OrderItemID", orderItemID);
                                    modifierParams.Add("@ModifierID", modifier.modifierID);
                                    modifierParams.Add("@SelectMode", modifier.selectMode);
                                    modifierParams.Add("@PortalID", portalId);
                                    modifierParams.Add("@UserID", userId);
                                    await db.ExecuteAsync(
                                        "sp_NV_InsertOrderModifier",
                                        modifierParams,
                                        commandType: CommandType.StoredProcedure,
                                        transaction: transaction
                                    );
                                }
                            }

                            foreach (var payment in check.payments)
                            {
                                var paymentParams = new DynamicParameters();
                                paymentParams.Add("@OrderID", orderId);
                                paymentParams.Add("@CheckID", checkID);
                                paymentParams.Add("@PortalID", portalId);
                                paymentParams.Add("@UserID", userId);
                                paymentParams.Add("@PayType", payment.payType);
                                paymentParams.Add("@PayAmount", payment.payAmount);

                                var paymentID = await db.QuerySingleAsync<int>(
                                    "sp_NV_InsertOrderPayment",
                                    paymentParams,
                                    commandType: CommandType.StoredProcedure,
                                    transaction: transaction
                                );

                                foreach (var log in payment.paymentLogs)
                                {
                                    var logParams = new DynamicParameters();
                                    logParams.Add("@OrderID", orderId);
                                    logParams.Add("@PaymentID", paymentID);
                                    logParams.Add("@ResultCode", log.ResultCode);
                                    logParams.Add("@ResultTxt", log.ResultTxt);
                                    logParams.Add("@ApprovedAmount", log.ApprovedAmount);
                                    logParams.Add("@AuthCode", log.AuthCode);
                                    logParams.Add("@AvsResponse", log.AvsResponse);
                                    logParams.Add("@BogusAccountNum", log.BogusAccountNum);
                                    logParams.Add("@CardType", log.CardType);
                                    logParams.Add("@CvResponse", log.CvResponse);
                                    logParams.Add("@ExtData", log.ExtData);
                                    logParams.Add("@ExtraBalance", log.ExtraBalance);
                                    logParams.Add("@HostResponse", log.HostResponse);
                                    logParams.Add("@HostCode", log.HostCode);
                                    logParams.Add("@Message", log.Message);
                                    logParams.Add("@RawResponse", log.RawResponse);
                                    logParams.Add("@RefNum", log.RefNum);
                                    logParams.Add("@RemainingBalance", log.RemainingBalance);
                                    logParams.Add("@RequestedAmount", log.RequestedAmount);
                                    logParams.Add("@SigFileName", log.SigFileName);
                                    logParams.Add("@SignData", log.SignData);
                                    logParams.Add("@Timestamp", log.Timestamp);
                                    logParams.Add("@RequestType", log.RequestType);

                                    await db.ExecuteAsync(
                                        "sp_NV_InsertOrderPaymentLog",
                                        logParams,
                                        commandType: CommandType.StoredProcedure,
                                        transaction: transaction
                                    );
                                }
                            }
                        }

                        transaction.Commit();
                        return orderId;
                    }
                    catch (System.Exception ex)
                    {
                        transaction.Rollback();
                        throw new System.Exception("Error inserting online order hierarchy via Stored Procedures.", ex);
                    }
                }
            }
        }

        public async Task<string?> GetOrderDataAsync1(int PortalID, GetOrderParams p)
        {
            var JsonData = JsonConvert.SerializeObject(p);
            using var conn = new SqlConnection(_connectionString);
            var query = @"sp_NV_GetOrderData @OrderID,@CheckID,@PortalID";
            var _data = await conn.QueryFirstOrDefaultAsync<string>(query, new { p.orderID,p.checkID, PortalID });
            return _data;
        }
        public async Task<OrderDto> GetOrderDataAsync(GetOrderParams p, int portalID)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new
                {
                    OrderID = p.orderID,
                    CheckID = p.checkID, 
                    PortalID = portalID
                };
                using (var multi = await db.QueryMultipleAsync(
                    "sp_NV_GetOrderData", 
                    parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    var order = await multi.ReadFirstOrDefaultAsync<OrderDto>();
                    if (order == null)
                    {
                        return null; 
                    }
                    var orderTotalAmounts = await multi.ReadFirstOrDefaultAsync<OrderAmountDto>();
                    var checks = (await multi.ReadAsync<CheckDto>()).ToList();
                    var checkAmounts = (await multi.ReadAsync<CheckAmountDto>()).ToList();
                    var items = (await multi.ReadAsync<ItemDto>()).ToList();
                    var modifiers = (await multi.ReadAsync<ModifierDto>()).ToList();
                    var payments = (await multi.ReadAsync<PaymentDto>()).ToList();
                    var paymentLogs = (await multi.ReadAsync<PaymentLogDto>()).ToList();
                    foreach (var check in checks)
                    {
                        check.Items = items.Where(i => i.CheckID == check.ID).ToList();
                        check.Payments = payments.Where(p => p.CheckID == check.ID).ToList();
                        foreach (var item in check.Items)
                        {
                            item.Modifiers = modifiers.Where(m => m.OrderItemID == item.ID).ToList();
                        }

                        foreach (var payment in check.Payments)
                        {
                            payment.PaymentLogs = paymentLogs.Where(pl => pl.PaymentID == payment.ID).ToList();
                        }
                        check.Amounts = checkAmounts.Where(ca => ca.CheckID == check.ID).First();
                    }
                    order.Checks = checks;
                    order.TotalAmounts = orderTotalAmounts;
                    return order;
                }
            }
        }
    }
}
