using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class BottomLine
    {
        public decimal EventTotal { get; set; }
        public decimal RouteTotal { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal ProfitPercentage { get; set; }
    }
}