namespace CoreApi.Model.Order
{
    public class PaymentLogParams
    {
        public string ResultCode { get; set; }
        public string ResultTxt { get; set; }
        public string ApprovedAmount { get; set; }
        public string AuthCode { get; set; }
        public string AvsResponse { get; set; }
        public string BogusAccountNum { get; set; }
        public string CardType { get; set; }
        public string CvResponse { get; set; }
        public string ExtData { get; set; }
        public string ExtraBalance { get; set; }
        public string HostResponse { get; set; }
        public string HostCode { get; set; }
        public string Message { get; set; }
        public string RawResponse { get; set; }
        public string RefNum { get; set; }
        public string RemainingBalance { get; set; }
        public string RequestedAmount { get; set; }
        public string SigFileName { get; set; }
        public string SignData { get; set; }
        public string Timestamp { get; set; }
        public string RequestType { get; set; }

    }
}
