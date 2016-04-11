using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class DriverManager
    {
        public int GetAmountOfMinutesOfDriverSinceLastPayment(string date)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.ExecuteQuery<int>("SELECT sum(DATEDIFF(minute, timeStarted,timeended)) from route where Date >= Convert(datetime, date )").First();
                
            }
        }
    }
} 