using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class BottomLineManager
    {
        public decimal GetTotalSpentOnInventory(string ices, string kliens, string paperGoods, string cones, string toppings)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var inventory = context.Expenses.ToList().Where(e => e.Name == ices || e.Name == kliens || e.Name == paperGoods).ToList();
                return inventory.Sum(s => s.Amount);
            }
        }
    }
}