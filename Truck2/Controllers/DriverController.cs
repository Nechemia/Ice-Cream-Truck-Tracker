using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Truck2.Models;

namespace Truck2.Controllers
{
    public class DriverController : Controller
    {
        

        public ActionResult Driver()
        {
            //DriverManager dm = new DriverManager();
            //string d = "01/06/2015";
            //int k = dm.GetAmountOfMinutesOfDriverSinceLastPayment(d);
            //return View(k);
            return View();
        }

    }
}
