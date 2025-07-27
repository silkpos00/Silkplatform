namespace CoreApi.Model.Order
{
    public class OrderParams
    {
        public int orderTypeID { get; set; }
        public int dineNo { get; set; } = 0;
        public string stationIP { get; set; }
        public string note { get; set; } = "";
        public int appID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string aptNo { get; set; }
        public string zipcode { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string email { get; set; }
        public List<CheckParams> checks { get; set; }
        
    }
}
