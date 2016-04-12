using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class MoneySpentManager
    {
        public List<Event> GetEvents()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Event>(e => e.Driver);
                context.LoadOptions = loadOptions;

                return context.Events.ToList();

                //return context.Events.ToList();
            }
        }
        public List<Expense> GetExpenses()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.Expenses.ToList();
            }
        }
        public void AddExpense(Expense expense)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Expenses.InsertOnSubmit(expense);
                context.SubmitChanges();
            }
        }
        public decimal GetTotalExpenses()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.Expenses.Sum(x => x.Amount);
            }
        }
        public void DeleteExpense(int id)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var expense = context.Expenses.FirstOrDefault(e => e.Id == id);
                context.Expenses.DeleteOnSubmit(expense);
                context.SubmitChanges();

            }
        }
        public void UpdateExpense(Expense e)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Expenses.Attach(e);
                context.Refresh(RefreshMode.KeepCurrentValues, e);
                context.SubmitChanges();
            }
        }

    }
}