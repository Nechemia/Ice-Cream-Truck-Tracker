using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using Truck2.Models;

namespace Truck2.Controllers
{
    public class MoneyMadeController : Controller
    {
        

        public ActionResult MoneyMade()
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            RoutesEvents re = new RoutesEvents();
            re.Routes = mm.GetRoutes();
           re.Events = mm.GetEvents();
           re.EventsAmount = mm.GetTotalEvents();
           re.RoutesAmount = mm.GetTotalRoute();
            return View(re);
        }
        [HttpPost]
        public void AddRoute(int amountMade, TimeSpan ? timeStarted, TimeSpan ? timeEnded, string driverName, DateTime date)
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            Route r = new Route();
            r.AmountMade = amountMade;
            r.Date = date;
            var driver = mm.GetDriverByName(driverName);
            r.DriverId = driver.Id;
            r.TimeEnded = timeEnded;
            r.TimeStarted = timeStarted;
            mm.AddRoute(r);
            
            
        }
        public void UpdateRoute(int id, decimal amountMade, TimeSpan ? timeStarted, TimeSpan ? timeEnded, string driverName, DateTime date)
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            Route r = new Route();
            r.Id = id;
            r.AmountMade = amountMade;
            r.TimeStarted = timeStarted;
            r.TimeEnded = timeEnded;
            var driver = mm.GetDriverByName(driverName);
            r.DriverId = driver.Id;
            r.Date = date;
            mm.UpdateRoute(r);
        }

        [HttpPost]
        public void AddEvent(string name, string productType, int ? amountOfPeople, int amountMade, TimeSpan ? timeStarted, TimeSpan ? timeEnded, string driverName, DateTime date, string eventType)
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            Event e = new Event();
            e.AmountMade = amountMade;
            e.AmountOfPeople = amountOfPeople;
            e.Date = date;
            var driver = mm.GetDriverByName(driverName);
            e.DriverId = driver.Id;
            e.Name = name;
            e.ProductType = productType;
            e.TimeEnded = timeEnded;
            e.TimeStarted = timeStarted;
            e.EventType = eventType;
            mm.AddEvent(e);
            
        }
        [HttpPost]
        public void DeleteRoute(int id)
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            mm.DeleteRoute(id);
        }
        [HttpPost]
        public void DeleteEvent(int id)
        {
            MoneyMadeManager mm = new MoneyMadeManager();
            mm.DeleteEvent(id);
        }
        [HttpPost]
        public void UpdateEvent(int editId, string name, string productType, int ? amountOfPeople, decimal amountMade, TimeSpan ? timeStarted, TimeSpan ? timeEnded, string driverName, DateTime ? date, string eventType)
        {
            MoneyMadeManager mm = new MoneyMadeManager();
             Event e = new Event();
             e.Id = editId;
             e.AmountMade = amountMade;
             e.AmountOfPeople = amountOfPeople;
             e.Date = date;
             var driver = mm.GetDriverByName(driverName);
             e.DriverId = driver.Id;
             e.Name = name;
             e.ProductType = productType;
             e.TimeEnded = timeEnded;
             e.TimeStarted = timeStarted;
             e.EventType = eventType;
            mm.UpdateEvent(e);
        }
    }
}
