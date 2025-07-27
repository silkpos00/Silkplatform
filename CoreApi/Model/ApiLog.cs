namespace CoreApi.Model
{
    public class ApiLog
    {
        public string Path { get; set; }
        public string Method { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public int StatusCode { get; set; }
        public int ElapsedTimeMs { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
