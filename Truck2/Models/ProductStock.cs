using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class ProductStock
    {
        public List<AddStock> StockList { get; set; }
        public decimal TotalSpentOnIces { get; set; }
        public decimal TotalSpentOnIceCream { get; set; }
        public decimal TotalAmountShouldHaveMade { get; set; }
    }
}