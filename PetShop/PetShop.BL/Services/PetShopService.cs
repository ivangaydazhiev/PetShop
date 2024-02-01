using PetShop.BL.Interfaces;
using PetShop.Models.Requests;
using PetShop.Models.Responses;
namespace PetShop.BL.Services
{
    public class PetShopService : IPetShopService
    {
        private readonly IPetService _petService;
        private readonly IProductService _productService;

        public PetShopService(
            IPetService petService,
            IProductService productService)
        {
            _petService = petService;
            _productService = productService;
        }

        public int CheckPetCount(int input)
        {
            if(input < 0) return 0;

            var petCount = _petService.GetAll();

            return petCount.Count + input;
        }

        public GetAllPetsAndProductsResponse GetAllPetsAndProducts(GetAllPetsAndProductsRequest request)
        {
            var response = new GetAllPetsAndProductsResponse
            {
                Pets = _petService
                    .GetAllPetsByAgeAndType(
                    request.MinPetAge,
                    request.PetType),
                Products = _productService
                .GetById(request.ProductId)
            };

            return response;
        }
    }
}
