using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truck2.Models;

namespace Truck2.Controllers
{
    public class BottomLineController : Controller
    {
        //
        // GET: /BottomLine/

        public ActionResult BottomLine()
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            RoutesEvents re = new RoutesEvents();
            BottomLine bl = new BottomLine();
            bl.EventTotal = mm.GetTotalEvents();
            bl.RouteTotal = mm.GetTotalRoute();


            MoneySpentManager ms = new MoneySpentManager();
            ExpenseTotal et = new ExpenseTotal();
            bl.TotalExpenses = ms.GetTotalExpenses();
            bl.FinalAmount = (bl.EventTotal + bl.RouteTotal) - bl.TotalExpenses;
            bl.ProfitPercentage = bl.FinalAmount / (bl.EventTotal + bl.RouteTotal) * 100;

            BottomLineManager blm = new BottomLineManager();
            bl.TotalSpentOnInventory = blm.GetTotalSpentOnInventory("Ices", "Kliens", "Paper Goods", "Cones", "Toppings");
            var amountWithoutInventory = (bl.EventTotal + bl.RouteTotal) - blm.GetTotalSpentOnInventory("Ices", "Kliens", "Paper Goods", "Cones", "Toppings");
            bl.ProfitPercentageFromAmountSpentOnInventory = amountWithoutInventory / (bl.EventTotal + bl.RouteTotal) * 100;
            return View(bl);
        }

    }
}
