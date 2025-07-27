namespace CoreApi.Model
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }         // موفقیت یا خطا
        public string Message { get; set; }      // پیام
        public T Data { get; set; }              // داده برگشتی (می‌تونه null باشه)
    }
}
