namespace BusBooking.Models.Models
{
    public class AddUserRequest
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string RoleType { get; set; }
    }
}
