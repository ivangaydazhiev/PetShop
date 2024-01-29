using PetShop.DL.Interfaces;
using PetShop.DL.MemoryDb;
using PetShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
           return InMemoryDb.ProductsData.ToList();
        }

        public Product GetById(int id)
        {
            return InMemoryDb.ProductsData.First(p => p.Id == id);
        }

        public void Add(Product product)
        {
            InMemoryDb.ProductsData.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = InMemoryDb.ProductsData.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var productToDelete = InMemoryDb.ProductsData.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                InMemoryDb.ProductsData.Remove(productToDelete);
            }
        }
    }
}
