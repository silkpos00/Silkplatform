namespace CoreApi.Model.Order
{
    public class ItemParams
    {
        public int itemID { get; set; }
        public int qty { get; set; }
        public float weight { get; set; } = 0;
        public string note { get; set; } = "";
        public List<ModifierParams> modifiers { get; set; }
    }
}
