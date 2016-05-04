using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Truck2.Models
{
    public class AddStockManager
    {
        public List<AddStock> GetAddStocks()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<AddStock>(e => e.Product);
                context.LoadOptions = loadOptions;

                return context.AddStocks.ToList();
               
            }
        }
        public void AddStock(AddStock addStock)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.AddStocks.InsertOnSubmit(addStock);
                context.SubmitChanges();
            }
        }
        public void AddProduct(Product p)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.Products.InsertOnSubmit(p);
                context.SubmitChanges();
            }
        }
        public Product GetProductByName(string name)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                return context.Products.FirstOrDefault(x => x.Name == name);
            }
        }
        public decimal GetTotalAmountShouldHaveMadeFromProduct(int passedInId)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<AddStock>(e => e.Product);
                context.LoadOptions = loadOptions;

                var item = context.AddStocks.Where(d => d.Id == passedInId);
                var totalProductAdded = item.Sum(d => d.Amount);
                var soldFor = context.Products.First(p => p.Id == passedInId).SoldFor;
                return totalProductAdded * soldFor;
            }
        }

        public decimal GetTotalAmountSpentOnIces()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<AddStock>(e => e.Product);
                context.LoadOptions = loadOptions;
                var twinPops = context.AddStocks.Where(d => d.Id == 1);
                var totalTwinsAdded = twinPops.Sum(d => d.Amount);
                var averageTwinPrice = context.Products.First(p => p.Id == 1).AveragePrice;
                var totalTwin = totalTwinsAdded * averageTwinPrice;

                var luigi = context.AddStocks.Where(d => d.Id == 2);
                var totalLuigiAdded = luigi.Sum(d => d.Amount);
                var averageLuigiPrice = context.Products.First(p => p.Id == 2).AveragePrice;
                var totalLuigi = totalLuigiAdded * averageLuigiPrice;

                return totalTwin + totalLuigi;
                
            }
        }
        public decimal GetTotalAmountSpentOnIceCream()
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<AddStock>(e => e.Product);
                context.LoadOptions = loadOptions;
                var softIceCream = context.AddStocks.Where(d => d.Id == 3);
                var totalSoftAdded = softIceCream.Sum(d => d.Amount);
                var averageSoftPrice = context.Products.First(p => p.Id == 1).AveragePrice;
               return  totalSoftAdded * averageSoftPrice;
            }
        }
        
        
       
        public void DeleteStock(int id)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                var Stock = context.AddStocks.FirstOrDefault(s => s.Id == id);
                context.AddStocks.DeleteOnSubmit(Stock);
                context.SubmitChanges();

            }
        }
        public void UpdateStock(AddStock a)
        {
            using (var context = new TruckDataContext(@"Data Source=.\sqlexpress;Initial Catalog=Truck;Integrated Security=True"))
            {
                context.AddStocks.Attach(a);
                context.Refresh(RefreshMode.KeepCurrentValues, a);
                context.SubmitChanges();
            }
        }
        
    }
}