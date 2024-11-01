using Newtonsoft.Json;
namespace BusBooking.Models.Models
{
    public class BookingDetails
    {
        public string BookedDate { get; set; }
        public string BusId { get; set; }
        public string BookingInfo { get; set; }

        public List<BookingInfo> BookingInformation
        {
            get
            {
                if(!string.IsNullOrEmpty(BookingInfo))
                {
                    return JsonConvert.DeserializeObject<List<BookingInfo>>(BookingInfo);
                }
                else
                {
                    return new List<BookingInfo>();
                }
            }
        }
    }
}
