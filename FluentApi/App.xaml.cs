using FluentApi.DataAccess.EFramerworkServer;
using FluentApi.Domain.Abstraction;
using FluentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FluentApi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;

        public App()
        {
            DB = new EFUnitOfWork();
            using(var context = new MyContext())
            {
                try
                {
                    context.Database.CreateIfNotExists();
                }
                catch (Exception)
                {

                }
            }

            if(DB.CustomerRepository.GetAllData().Count() == 0)
            {
                var c1 = new Customer
                {
                    City="Baku",
                    CompanyName="STEP IT ACADEMY",
                    ContactName="12345678",
                    Country="Azerbaijan"
                };

                var c2 = new Customer
                {
                    City = "Sillicon Valley",
                    CompanyName = "Elvin MMC",
                    ContactName = "45645344",
                    Country = "USA"
                };

                DB.CustomerRepository.AddData(c1);
                DB.CustomerRepository.AddData(c2);

            }


            if(DB.OrderRepository.GetAllData().Count() == 0)
            {

                var o1 = new Order
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-3),
                    ImagePath = "https://cdn.tmobile.com/content/dam/t-mobile/en-p/cell-phones/apple/Apple-iPhone-14-Pro-Max/Gold/Apple-iPhone-14-Pro-Max-Gold-frontimage.png"
                };

                var o2 = new Order
                {
                    CustomerId = 2,
                    OrderDate = DateTime.Now.AddDays(-5),
                    ImagePath = "https://optimal.az/image/cache/catalog/products/telefon-ve-planshetler/telefonlar-ve-planshetler/iphone-13-starlight-select-2021-400x400.png?v=6"
                };


                DB.OrderRepository.AddData(o1);
                DB.OrderRepository.AddData(o2);
            }

        }

        

    }
}
