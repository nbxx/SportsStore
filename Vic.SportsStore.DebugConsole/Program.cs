using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                var product = new Product()
                {
                    Name = "abc",
                    Description = "efg",
                    Category = "hij",
                    Price = 123,

                };

                var products = ctx.Products;


                ctx.Products.Add(product);
                ctx.SaveChanges();
            }
        }
    }
}
