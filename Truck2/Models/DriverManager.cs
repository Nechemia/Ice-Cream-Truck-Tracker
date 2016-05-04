using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class DriverManager
    {
        //public int GetAmountOfMinutesOfDriverSinceLastPayment(string date)
        //{
        //    using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
        //    {
        //        return context.ExecuteQuery<int>("SELECT sum(DATEDIFF(minute, timeStarted,timeended)) from route where Date >= Convert(datetime, date )").First();
                
        //    }
        //}
//        public int GetAmountOfMinutesOfDriverSinceLastPayment(string date)
//        {
//            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
//            {
//                return context.ExecuteQuery<List<DriverTimes>>(@"select SUM(DATEDIFF(minute, timeStarted,timeended)) AS 'Total Time', R.DriverId, R.Date
//                                                       FROM Route R
//                                                       GROUP BY R.DriverId, R.Date").ToList(); ;
                
//            }
//        }

        
    }
} 