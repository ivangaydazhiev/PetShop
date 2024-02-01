using PetShop.Models.Models;
using System.ComponentModel;

namespace PetShop.BL.Interfaces
{
    public interface IPetService
    {
        List<Pet> GetAll();
        List<Pet> GetAllPetsByAgeAndType(int minAge, string type);
        Pet GetById(int id);
        void Add (Pet pet);

        void Update (Pet pet);

        void Delete (int id);
    }
}
