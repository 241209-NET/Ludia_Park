using Moq;
using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;
using LudisFoodCourt.Api.Service;

namespace LudisFoodCourt.TEST;


public class FoodServiceTests()
{
  [Fact]
  public void DeleteFood_FoodExistsTest()
  {
    // Arrange
    Mock<IFoodRepository> mockFoodRepo = new();
    Mock<IVendorService> mockVendorService = new();

    var foodId = 1;
    mockFoodRepo.Setup(repo => repo.Delete(foodId)).Returns(true);

    // real food service instance with mocked repos
    var foodService = new FoodService(mockFoodRepo.Object, mockVendorService.Object);

    // Act: using real food service, delete food method in the fake repo with fake id.
    foodService.DeleteFood(foodId); // this is void type

    // Assert
    mockFoodRepo.Verify(repo => repo.Delete(foodId), Times.Once);
  }

  [Fact]
  public void DeleteFood_FoodDoesNotExistTest()
  {
    // Arrange
    Mock<IFoodRepository> mockFoodRepo = new();
    Mock<IVendorService> mockVendorService = new();

    var foodId = 1;
    mockFoodRepo.Setup(repo => repo.Delete(foodId)).Returns(false); // not successful deletion

    // real food service instance with mocked repos
    var foodService = new FoodService(mockFoodRepo.Object, mockVendorService.Object);

    // Act + Assert at once
    // in this test, when DeleteFood(foodId) is called, make sure it throws this exception.
    Assert.Throws<KeyNotFoundException>(() => foodService.DeleteFood(foodId));
  }
}