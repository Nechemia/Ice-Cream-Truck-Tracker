using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class ExpenseTotal
    {
        public List<Expense> Expenses { get; set; }
        public decimal TotalExpenseAmount { get; set; }
       
    }
}