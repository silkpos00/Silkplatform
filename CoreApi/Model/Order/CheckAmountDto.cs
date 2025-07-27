namespace CoreApi.Model.Order
{
    public class CheckAmountDto
    {
        public int CheckID { get; set; }
        public float Sale { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
    }
}
