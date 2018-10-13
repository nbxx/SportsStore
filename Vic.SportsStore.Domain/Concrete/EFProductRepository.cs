using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        public EFDbContext EFDbContext { get; set; }

        public IEnumerable<Product> Products
        {
            get
            {
                return EFDbContext.Products;
            }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                EFDbContext.Products.Add(product);
            }
            else
            {
                Product dbEntry = EFDbContext.Products.Find(product.ProductId);

                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }

            EFDbContext.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = EFDbContext.Products.Find(productId);

            if (dbEntry != null)
            {
                EFDbContext.Products.Remove(dbEntry);
                EFDbContext.SaveChanges();
            }

            return dbEntry;
        }

    }

}
