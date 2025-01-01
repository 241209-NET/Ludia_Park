using Moq;
using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;
using LudisFoodCourt.Api.Service;

namespace LudisFoodCourt.TEST;


public class VendorServiceTests
{
    [Fact]
    public void CreateNewVendorTest()
    {
        // Arrange
        Mock<IVendorRepository> mockVendorRepo = new();
        Mock<IFoodRepository> mockFoodRepo = new();
        VendorService vendorService = new(mockVendorRepo.Object, mockFoodRepo.Object);

        var newVendor = new Vendor
        {
            Id = 1,
            Name = "Waffle House",
            FoodType = "Waffles"
        };

        mockVendorRepo.Setup(repo => repo.Add(It.IsAny<Vendor>())).Returns(newVendor);

        // Act
        var res = vendorService.CreateVendor(newVendor);

        // Assert
        Assert.Equal("Waffle House", res.Name);
        Assert.Equal("Waffles", res.FoodType);
        mockVendorRepo.Verify(x => x.Add(It.IsAny<Vendor>()), Times.Once());
    }

    [Fact]
    public void GetAllVendorsTest()
    {
        // Arrange
        Mock<IVendorRepository> mockVendorRepo = new();
        Mock<IFoodRepository> mockFoodRepo = new();

        var vendors = new List<Vendor>
        {
            new Vendor { Id = 1, Name = "Waffle House", FoodType = "Waffles" },
            new Vendor { Id = 1, Name = "Pete's Place", FoodType = "Deli" }
        };

        mockVendorRepo.Setup(repo => repo.GetAll()).Returns(vendors);

        var vendorService = new VendorService(mockVendorRepo.Object, mockFoodRepo.Object);

        // Act
        var res = vendorService.GetAllVendors();

        // Assert
        Assert.NotNull(res);
        Assert.Equal(2, res.Count());  // 2 vendors in this test
        Assert.Equal("Waffle House", res.First().Name);  // Check if the first vendor's name matches
        Assert.Equal("Pete's Place", res.Last().Name);   // check if 2nd's name matches

        mockVendorRepo.Verify(repo => repo.GetAll(), Times.Once());
    }

    [Fact]
    public void GetVendorByIdTest()
    {
        // Arrange
        Mock<IVendorRepository> mockVendorRepo = new();
        Mock<IFoodRepository> mockFoodRepo = new();

        var vendorId = 1;           // let's say u wanna find vendor 1
        var vendor = new Vendor     // make example vendor 1
        {
            Id = vendorId,
            Name = "Waffle House",
            FoodType = "Waffles"
        };

        // setup the mock repo to find by our example vendorId
        mockVendorRepo.Setup(repo => repo.GetById(vendorId)).Returns(vendor);

        // after setup, pass mock into a new vendor service
        var vendorService = new VendorService(mockVendorRepo.Object, mockFoodRepo.Object);

        // Act: do the thing
        var res = vendorService.GetVendorById(vendorId);
        
        // Assert
        Assert.NotNull(res);
        Assert.Equal(vendorId, res.Id);
        Assert.Equal("Waffle House", res.Name);
    }

    [Fact]
    public void AddFoodToMenu_VendorExistsTest()
    {
        // Arrange
        Mock<IVendorRepository> mockVendorRepo = new();
        Mock<IFoodRepository> mockFoodRepo = new();

        var vendorId = 1;
        var food = new Food
        {
            Name = "Waffle",
            Price = 5.99M       // need M for decimal type
        };

        // mocking getById to get back a vendor (check if it exists)
        // we don't need to make a full vendor object, just a 간딴한 one, only checking if it actually returns what we give it.
        mockVendorRepo.Setup(repo => repo.GetById(vendorId)).Returns(new Vendor { Id = vendorId, Name = "Waffle House" });

        // mocking adding food (any food) to return "Waffle" food.
        mockFoodRepo.Setup(repo => repo.Add(It.IsAny<Food>())).Returns(food);

        var vendorService = new VendorService(mockVendorRepo.Object, mockFoodRepo.Object);

        // Act
        var res = vendorService.AddFoodToMenu(vendorId, food);

        // Assert
        Assert.NotNull(res);
        Assert.Equal(food.Name, res.Name);
        Assert.Equal(food.Price, res.Price);
        Assert.Equal(vendorId, res.VendorId);
    }

    [Fact]
    public void AddFoodToMenu_VendorDoesNotExistTest()
    {
        // Arrange
        Mock<IVendorRepository> mockVendorRepo = new();
        Mock<IFoodRepository> mockFoodRepo = new();

        var vendorId = 777; // Vendor that doesn't exist
        var food = new Food // try adding this food to a ghost vendor
        {
            Name = "Waffle",
            Price = 5.99m
        };

        // Mock GetById, return Vendor type null (vendor doesn't exist)
        mockVendorRepo.Setup(repo => repo.GetById(vendorId)).Returns((Vendor)null);

        var vendorService = new VendorService(mockVendorRepo.Object, mockFoodRepo.Object);

        // Act
        var res = vendorService.AddFoodToMenu(vendorId, food);

        // Assert
        Assert.Null(res);  // must be null cuz vendor doesn't exist
    }

}