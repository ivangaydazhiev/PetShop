namespace PetShop.Models.Requests
{
    public class GetAllPetsAndProductsRequest
    {
        public int MinPetAge { get; set; }

        public string PetType { get; set; } = string.Empty;

        public bool IncludeOutOfStock { get; set; }

        public int ProductId { get; set; }
    }
}
