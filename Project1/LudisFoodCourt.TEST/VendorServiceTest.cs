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

    
}