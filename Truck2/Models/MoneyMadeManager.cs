using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class MoneyMadeManager
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
        public List<Route> GetRoutes()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Route>(r => r.Driver);
                context.LoadOptions = loadOptions;

                return context.Routes.ToList();   
            }
        }
        public void AddRoute(Route Route)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Routes.InsertOnSubmit(Route);
                context.SubmitChanges();
            }
        }
        public void AddEvent(Event Event)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Events.InsertOnSubmit(Event);
                context.SubmitChanges();
            }
        }
        public Driver GetDriverByName(string name)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.Drivers.FirstOrDefault(x => x.Name == name);
            }
        }
        public decimal GetTotalEvents()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.Events.Sum(x => x.AmountMade);            
            }
        }
        public decimal GetTotalRoute()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.Routes.Sum(x => x.AmountMade);
            }
        }
        public void DeleteRoute(int id)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var route = context.Routes.FirstOrDefault(r => r.Id == id);
                context.Routes.DeleteOnSubmit(route);
                context.SubmitChanges();
                
            }
        }
        public void DeleteEvent(int id)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var even = context.Events.FirstOrDefault(e => e.Id == id);
                context.Events.DeleteOnSubmit(even);
                context.SubmitChanges();

            }
        }
        public void UpdateEvent(Event e)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Events.Attach(e);
                context.Refresh(RefreshMode.KeepCurrentValues, e);
                context.SubmitChanges();
            }
        }
        public void UpdateRoute(Route r)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Routes.Attach(r);
                context.Refresh(RefreshMode.KeepCurrentValues, r);
                context.SubmitChanges();
            }
        }
        

       
    }
}