namespace CoreApi.Model.Order
{
    public class CheckParams
    {
        public string checkName { get; set; } = "";
        public int isMaster { get; set; } = 0;
        public List<ItemParams> items { get; set; }
        public List<PaymentParams> payments { get; set; }
    }
}
