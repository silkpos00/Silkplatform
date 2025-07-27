using System.Text.Json.Serialization;

namespace CoreApi.Model.Order
{
    public class PaymentLogDto
    {
        public int ID { get; set; }
        [JsonIgnore]
        public int PaymentID { get; set; } // برای ارتباط با Payment
        public string ResultCode { get; set; }
        public string ResultTxt { get; set; }
        public decimal ApprovedAmount { get; set; }
        public string AuthCode { get; set; }
        public string AvsResponse { get; set; }
        public string BogusAccountNum { get; set; }
        public string CardType { get; set; }
        public string CvResponse { get; set; }
        public string ExtData { get; set; }
        public decimal ExtraBalance { get; set; }
        public string HostResponse { get; set; }
        public string HostCode { get; set; }
        public string Message { get; set; }
        public string RawResponse { get; set; }
        public string RefNum { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal RequestedAmount { get; set; }
        public string SigFileName { get; set; }
        public string SignData { get; set; }
        public string Timestamp { get; set; }
        public string RequestType { get; set; }
    }
}
