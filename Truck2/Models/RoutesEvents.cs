using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class RoutesEvents
    {
        public List<Route> Routes {get;set;}
        public List<Event> Events { get; set; }
        public decimal EventsAmount { get; set; }
        public decimal RoutesAmount { get; set; }
        public decimal AmountOwed { get; set; }
    }
}