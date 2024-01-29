﻿
using PetShop.Models.Models;

namespace PetShop.DL.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);

        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}
