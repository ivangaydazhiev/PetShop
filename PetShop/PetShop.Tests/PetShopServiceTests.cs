using Moq;
using PetShop.BL.Services;
using PetShop.DL.Interfaces;
using PetShop.DL.Repositories;
using PetShop.Models.Models;
using PetShop.Models.Requests;
using PetShop.Models.Responses;

namespace PetShop.Tests;

public class PetShopServiceTests
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



    [Fact]
    public void CheckPetCount_Possitive()
    {
        var input = 5;
        var expectedCount = 8;
        var mockedPetRepository = new Mock<IPetRepository>();


            mockedPetRepository.Setup(x => x.GetAll())
            .Returns(PetsData);

        var petService = new PetService(mockedPetRepository.Object);
        var productService = new ProductService(new ProductRepository());
        var service = new PetShopService(petService, productService);

        var result = service.CheckPetCount(input);

        Assert.Equal(expectedCount, result);

    }


    [Fact]
    public void CheckPetCount_Negative()
    {
        var input = -5;
        var mockedPetRepository = new Mock<IPetRepository>();


        mockedPetRepository.Setup(x => x.GetAll())
        .Returns(PetsData);

        var petService = new PetService(mockedPetRepository.Object);
        var productService = new ProductService(new ProductRepository());
        var service = new PetShopService(petService, productService);

        var result = service.CheckPetCount(input);

        Assert.Equal(0, result);

    }

    [Fact]

    public void GetAllPetsAndProducts_CorrectResponse()
    {
        var request = new GetAllPetsAndProductsRequest
        {
            MinPetAge = 1,
            PetType = "Dog",
            ProductId = 1,
        };

        var mockedPetRepository = new Mock<IPetRepository>();
        var mockedProductRepository = new Mock<IProductRepository>();

        mockedPetRepository.Setup(x => x.GetAllPetsByAgeAndType(request.MinPetAge,
            request.PetType))
            .Returns(PetsData);

        mockedProductRepository.Setup(x => x.GetById(request.ProductId))
            .Returns(ProductsData!
            .FirstOrDefault(p => p.Id == request.ProductId)!);

        var petService = new PetService(mockedPetRepository.Object);
        var productService = new ProductService(mockedProductRepository.Object);
        var service = new PetShopService (petService, productService);


        var result = service.GetAllPetsAndProducts(request);

        Assert.NotNull(result);
        Assert.IsType<GetAllPetsAndProductsResponse>(result);
        Assert.NotNull(result.Pets);
        Assert.NotNull(result.Products);

    }
}