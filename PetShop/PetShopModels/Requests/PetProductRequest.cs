using Microsoft.AspNetCore.Routing.Constraints;

namespace PetShop.Models.Requests
{
    public class PetProductRequest
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Type { get; set; } = string.Empty;

        public double Price { get; set; }
    }
}
