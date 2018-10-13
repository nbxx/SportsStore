using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
    class Program
    {
        static string HashMD5(string text)
        {
            var source = Encoding.UTF8.GetBytes(text);

            using (MD5 hasher = MD5.Create())
            {
                var result = hasher.ComputeHash(source);

                return Convert.ToBase64String(result);
            }
        }

        static void Main(string[] args)
        {
            var pwdHash = HashMD5("pwd");

            //using (var ctx = new EFDbContext())
            //{
            //    for (int i = 0; i < 20; i++)
            //    {
            //        var product = new Product()
            //        {
            //            Name = "abc" + i.ToString(),
            //            Description = "efg" + i.ToString(),
            //            Category = "hij" + i.ToString(),
            //            Price = i + 1,
            //        };

            //        ctx.Products.Add(product);
            //    }


            //    ctx.SaveChanges();
            //}
        }
    }
}
