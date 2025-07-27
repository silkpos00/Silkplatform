namespace CoreApi.Model.Order
{
    public class OrderDto
    {
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        public string OrderTypeName { get; set; }
        public int DineNo { get; set; }
        public string StationIP { get; set; }
        public string Note { get; set; }
        public int AppID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AptNo { get; set; }
        public string Zipcode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Email { get; set; }

        public OrderAmountDto TotalAmounts { get; set; }
        public List<CheckDto> Checks { get; set; } = new List<CheckDto>();
    }
}
