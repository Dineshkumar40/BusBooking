using Newtonsoft.Json;
namespace BusBooking.Models.Models
{
    public class GetBookingDetails
    {
        public string UserId { get; set; }
        public string NoOfSeats { get; set; }
        public string BusId { get; set; }
        public string BookingId { get; set; }
        public string Month { get; set; }
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
