using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ActionResult Stock()
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
        [HttpPost]
        public void AddStock(string product, int amount, DateTime date)
        {
              AddStockManager asm = new AddStockManager();
              AddStock a = new AddStock();
              Product p = asm.GetProductByName(product);
              a.ProductId = p.Id;
              a.Amount = amount;
              a.Date = date;
              asm.AddStock(a);
        }
        [HttpPost]
        public void UpdateStock(int id, string product, int amount, DateTime date)
        {
            AddStockManager asm = new AddStockManager();
            AddStock a = new AddStock();
            Product p = asm.GetProductByName(product);
            a.ProductId = p.Id;
            a.Id = id;
            a.Amount = amount;
            a.Date = date;
            asm.UpdateStock(a);
        }
        [HttpPost]
        public void DeleteStock(int id)
        {
            AddStockManager asm = new AddStockManager();
            asm.DeleteStock(id);
        }

    }
}
