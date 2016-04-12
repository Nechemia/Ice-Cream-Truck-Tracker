using System;
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
        [HttpPost]
        public void AddExpense(decimal amount, string name, DateTime date)
        {
            MoneySpentManager ms = new MoneySpentManager();
            Expense e = new Expense();
            e.Amount = amount;
            e.Date = date;
            e.Name = name;
            //e.Other = other;
            ms.AddExpense(e);


        }
        public void UpdateExpense(int id, decimal amount, string name, DateTime date)
        {
            MoneySpentManager ms = new MoneySpentManager();
            Expense e = new Expense();
            e.Id = id;
            e.Amount = amount;
            e.Date = date;
            e.Name = name;
            ms.UpdateExpense(e);
        }
        public void DeleteExpense(int id)
        {
            MoneySpentManager ms = new MoneySpentManager();
            ms.DeleteExpense(id);
        }

    }
}
