using PetShop.Models.Models;

namespace PetShop.DL.MemoryDb
{
    public static class InMemoryDb
    {
        public static List<Pet> PetsData = new List<Pet>()
        {
            new Pet()
            {
                Id = 1,
                Name = "Clarissa",
                Age = 1,
                Type = "Cat"
            },

            new Pet()
            {
                Id = 2,
                Name = "Dave",
                Age = 2,
                Type = "Dog"
            },

            new Pet()
            {
                Id = 3,
                Name = "Raya",
                Age = 3,
                Type = "Bird"
            },
        };

        public static List<Product> ProductsData = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Food",
                Price = 10.80
            },

            new Product()
            {
                Id = 2,
                Name = "Brush",
                Price = 5.90
            },

            new Product()
            {
                Id = 3,
                Name = "Bed",
                Price = 14.50
            },
        };
    }
}
