using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class DriverTimes
    {
        public int TotalMinutes { get; set; }
        public int DriverId { get; set; }
        public DateTime Date { get; set; }
    }
}