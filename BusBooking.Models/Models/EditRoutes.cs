using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class EditRoutes:AddRoutes
    {
        public string RouteId { get; set; }
        public string RouteName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Duration { get; set; }

    }
}
