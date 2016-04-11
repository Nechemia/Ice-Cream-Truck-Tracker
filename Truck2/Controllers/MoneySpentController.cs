﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truck2.Models;

namespace Truck2.Controllers
{
    public class MoneySpentController : Controller
    {
        public ActionResult MoneySpent()
        {
            MoneySpentManager ms = new MoneySpentManager();
            ExpenseTotal et = new ExpenseTotal();
            et.Expenses = ms.GetExpenses();
            et.TotalExpenseAmount = ms.GetTotalExpenses();
            return View(et);
        }
        //[HttpPost]
        //public void AddRoute(decimal amount, string ? other, string name, DateTime date)
        //{
        //    MoneySpentManager ms = new MoneySpentManager();
        //    Expense e = new Expense();
        //    e.Amount = amount;
        //    e.Date = date;
        //    e.Name = name;
        //    e.Other = other;

        //    ms.AddExpense(e);


        //}
        //public void UpdateRoute(int id, decimal amountMade, TimeSpan? timeStarted, TimeSpan? timeEnded, string driverName, DateTime date)
        //{
        //    MoneyMadeManager mm = new MoneyMadeManager();
        //    Route r = new Route();
        //    r.Id = id;
        //    r.AmountMade = amountMade;
        //    r.TimeStarted = timeStarted;
        //    r.TimeEnded = timeEnded;
        //    var driver = mm.GetDriverByName(driverName);
        //    r.DriverId = driver.Id;
        //    r.Date = date;
        //    mm.UpdateRoute(r);
        //}

    }
}
