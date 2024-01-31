using Microsoft.AspNetCore.Mvc;
using PetShop.BL.Interfaces;
using PetShop.Models.Requests;
using PetShop.Models.Responses;
using PetShop.Validators;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetShopController : ControllerBase
    {
        private readonly IPetShopService _petShopService;

        public PetShopController(IPetShopService petShopService)
        {
            _petShopService = petShopService;
        }

        [HttpGet("GetPetCount/{input}")]

        public int GetPetCount(int input)
        {
            return _petShopService.CheckPetCount(input);
        }

        [HttpPost("GetAllPetsAndProducts")]

        public GetAllPetsAndProductsResponse? GetAllPetsAndProducts([FromBody] GetAllPetsAndProductsRequest request)
        {
            return _petShopService.GetAllPetsAndProducts(request);
        }

        [HttpPost("SomeEndPoint")]

        public string GetData([FromBody]PetProductRequest request)
        {
            return "Ok";
        }
    }
}
