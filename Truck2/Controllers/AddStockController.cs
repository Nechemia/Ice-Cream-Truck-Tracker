using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truck2.Models;

namespace Truck2.Controllers
{
    public class AddStockController : Controller
    {
        //
        // GET: /AddStock/

        public ActionResult AddStock()
        {
            AddStockManager asm = new AddStockManager();
            ProductStock ps = new ProductStock();
            ps.StockList = asm.GetAddStocks();
            ps.TotalSpentOnIces = asm.GetTotalAmountSpentOnIces();
            ps.TotalSpentOnIceCream = asm.GetTotalAmountSpentOnIceCream();
            var twin = asm.GetTotalAmountShouldHaveMadeFromProduct(1);
            var luigi = asm.GetTotalAmountShouldHaveMadeFromProduct(2);
            var soft = asm.GetTotalAmountShouldHaveMadeFromProduct(3);
            ps.TotalAmountShouldHaveMade = twin + luigi + soft;
            return View(ps); 
        }

    }
}
