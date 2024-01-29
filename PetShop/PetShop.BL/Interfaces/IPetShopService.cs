using PetShop.Models.Requests;
using PetShop.Models.Responses;

namespace PetShop.BL.Interfaces
{
    public interface IPetShopService
    {
        GetAllPetsAndProductsResponse GetAllPetsAndProducts(GetAllPetsAndProductsRequest request);

        int CheckPetCount(int input);
    }
}
