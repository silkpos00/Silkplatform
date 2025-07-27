using System.Text.Json.Serialization;

namespace CoreApi.Model.Order
{
    public class CheckDto
    {
        public int ID { get; set; }
        [JsonIgnore]
        public int OrderID { get; set; }
        public string CheckName { get; set; }
        public int IsMasterCheck { get; set; }
        public CheckAmountDto Amounts { get; set; }
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}
