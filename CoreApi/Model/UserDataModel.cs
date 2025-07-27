namespace CoreApi.Model
{
    public class UserDataModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserIsActive { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int PortalID { get; set; }
        public string PortalName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Zipcode { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Website { get; set; }
        public int PortalIsActive { get; set; }
        public int PortalTypeID { get; set; }
        public string Logo { get; set; }
    }
}
