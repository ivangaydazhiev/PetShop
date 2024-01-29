using PetShop.BL.Interfaces;
using PetShop.DL.Interfaces;
using PetShop.Models.Models;

namespace PetShop.BL.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public List<Pet> GetAll()
        {
            return _petRepository.GetAll();
        }

        public Pet GetById(int id)
        {
            return _petRepository.GetById(id);
        }

        public void Add(Pet pet)
        {
            _petRepository.Add(pet);
        }

        public void Update(Pet pet)
        {
            _petRepository.Update(pet);
        }

        public void Delete(int id)
        {
            _petRepository.Delete(id);
        }

        public List<Pet> GetAllPetsByAgeAndType(int minAge, string type, bool includeOutOfStock)
        {
            var allPets = _petRepository.GetAll();

            var result = allPets
                .Where(p => p.Age >= minAge)
                .Where(p => string.IsNullOrEmpty(type) || p.Type == type)
                .Where(p => includeOutOfStock)
                .ToList();

            return result;
        }
    }
}
