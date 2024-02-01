using PetShop.Models.Models;

namespace PetShop.DL.Interfaces
{
    public interface IPetRepository
    {
        List<Pet> GetAll();
        List<Pet> GetAllPetsByAgeAndType(int minAge, string type);
        Pet GetById(int id);
        void Add(Pet pet);  
        void Update(Pet pet);
        void Delete(int id);

    }
}
