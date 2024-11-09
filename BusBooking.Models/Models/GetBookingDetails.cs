using Newtonsoft.Json;
namespace BusBooking.Models.Models
{
    public class GetBookingDetails
    {
        public string NoOfSeats { get; set; }
        public string BusName { get; set; }
        public string Fare { get; set; }
        public string Month { get; set; }
        public string UserId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string SeatNumbers { get; set; }
        public string PassengerDetails { get; set; }

        public List<PassengerInfo> PassengerInformation
        {
            get
            {
                if(!string.IsNullOrEmpty(PassengerDetails))
                {
                    return JsonConvert.DeserializeObject<List<PassengerInfo>>(PassengerDetails);
                }
                else
                {
                    return new List<PassengerInfo>();
                }
            }
        }
    }
}
