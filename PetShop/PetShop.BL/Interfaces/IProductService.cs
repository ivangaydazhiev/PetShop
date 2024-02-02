using PetShop.Models.Models;
using System.ComponentModel;

namespace PetShop.BL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);    
        void Add (Product product);
        void Update (Product product);
        bool Delete (int id);

    }
}
