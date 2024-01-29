using PetShop.Models.Models;

namespace PetShop.Models.Responses
{
    public class GetAllPetsAndProductsResponse
    {
        public List<Pet>? Pets { get; set; }
        public Product? Products { get; set; } 
    }
}
