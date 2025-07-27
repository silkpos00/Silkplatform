namespace CoreApi.Model.Order
{
    public class PaymentParams
    {
        public float payType { get; set; }
        public float payAmount { get; set; }
        public List<PaymentLogParams>? paymentLogs { get; set; }
    }
}
