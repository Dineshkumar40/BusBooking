using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class SearchBuses
    {
        public string From {  get; set; }
        public string To { get; set; }
        public DateTime TravelDate { get; set; }       
    }
}
