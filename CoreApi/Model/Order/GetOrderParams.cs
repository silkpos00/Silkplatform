using System.Text.Json.Serialization;

namespace CoreApi.Model.Order
{
    public class GetOrderParams
    {
        public long orderID { get; set; }
        [JsonIgnore]
        public long checkID { get; set; } = 0;
    }
}
