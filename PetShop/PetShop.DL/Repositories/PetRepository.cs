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
    public class PetRepository : IPetRepository
    {
        public List<Pet> GetAll()
        {
            return InMemoryDb.PetsData.ToList();
        }

        public List<Pet> GetAllPetsByAgeAndType(int minAge, string type)
        {
            return InMemoryDb.PetsData
                .Where(p => p.Age >= minAge && p.Type == type)
                .ToList();
        }
        public Pet GetById(int id)
        {
            return InMemoryDb.PetsData.FirstOrDefault(p => p.Id == id)!;
        }

        public void Add(Pet pet)
        {
            InMemoryDb.PetsData.Add(pet);
        }

        public void Update(Pet pet)
        {
            var existingPet = InMemoryDb.PetsData.FirstOrDefault(p => p.Id == pet.Id);
            if(existingPet != null)
            {
                existingPet.Name = pet.Name;
                existingPet.Age = pet.Age;
                existingPet.Type = pet.Type;
            }
        }

        public void Delete(int id)
        {
            var pet = GetById(id);
           
            if(pet != null)
            {
                InMemoryDb.PetsData.Remove(pet);
            }
        }
    }
}
