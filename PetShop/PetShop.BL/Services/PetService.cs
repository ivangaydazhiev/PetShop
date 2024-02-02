using PetShop.BL.Interfaces;
using PetShop.DL.Interfaces;
using PetShop.Models.Models;
using System.Reflection.Metadata.Ecma335;

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

        public bool Delete(int id)
        {
            var pet = _petRepository.GetById(id);

            if(pet != null)
            {
                _petRepository.Delete(id);
                return true;
            }
            return false;
        }

        public List<Pet> GetAllPetsByAgeAndType(int minAge, string type)
        {
            var allPets = _petRepository.GetAll();
            
            if(allPets == null)
            {
                return new List<Pet>();
            }
            var result = allPets
                .Where(p => p.Age >= minAge)
                .Where(p => string.IsNullOrEmpty(type) || p.Type == type)
                .ToList();

            return result;
        }
    }
}
