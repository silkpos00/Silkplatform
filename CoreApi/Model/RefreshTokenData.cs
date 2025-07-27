namespace CoreApi.Model
{
    public class RefreshTokenData
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
