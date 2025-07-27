using System.Text.Json.Serialization;

namespace CoreApi.Model.Order
{
    public class ItemDto
    {
        public int ID { get; set; }
        [JsonIgnore]
        public int CheckID { get; set; }
        [JsonIgnore]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string SizeName { get; set; }
        public string CategoryName { get; set; }
        public int Qty { get; set; }
        public float Weight { get; set; }
        public string Note { get; set; }

        public List<ModifierDto> Modifiers { get; set; } = new List<ModifierDto>();
    }
}
