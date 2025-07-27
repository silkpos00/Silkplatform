using System.Text.Json.Serialization;

namespace CoreApi.Model.Order
{
    public class ModifierDto
    {
        public int ID { get; set; }
        [JsonIgnore]
        public int OrderItemID { get; set; }
        [JsonIgnore]
        public int ModifierID { get; set; }
        public string ModifierName { get; set; }
       
        [JsonIgnore]
        public int SelectMode { get; set; }
        public string SelectModeName { get; set; }
        public int IsIncluded { get; set; }
    }
}
