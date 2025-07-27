using System.Text.Json.Serialization;

namespace CoreApi.Model.Order
{
    public class PaymentDto
    {
        public int ID { get; set; }
        [JsonIgnore]
        public int OrderID { get; set; }
        [JsonIgnore]
        public int CheckID { get; set; } 
        [JsonIgnore]
        public int PayType { get; set; }
        public string PayTypeName { get; set; }
        public decimal PayAmount { get; set; }
        public List<PaymentLogDto> PaymentLogs { get; set; } = new List<PaymentLogDto>();
    }
}
