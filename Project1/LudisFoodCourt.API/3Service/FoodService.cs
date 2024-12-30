using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

namespace LudisFoodCourt.Api.Service;

public class FoodService : IFoodService
{
  private readonly IFoodRepository _foodRepository;
  private readonly IVendorService _vendorService;
  
  public FoodService(IFoodRepository foodRepository, IVendorService vendorService) 
  {
    _foodRepository = foodRepository;
    _vendorService = vendorService;
  }

  public Food? UpdateFood(int foodId, Food food)  // return updated food or null
  { 
    // 1. try to get the food
    var existingFood = _foodRepository.GetById(foodId);

    if (existingFood == null) return null;    // food not found

    // 2. check if VendorId exists
    bool vendorExists = _vendorService.CheckVendorExists(food.VendorId);
    if (!vendorExists)
    {
      return null;
    } 

    // 3. check if VendorId in req body matches existing food's VendorId
    if (existingFood.VendorId != food.VendorId)
    {
      return null;    // forbidden auth!!
    } 

    // 4. updating:
    existingFood.Name = food.Name;
    existingFood.Price = food.Price;
    // no need to override existingFood.VendorId since we validated it.

    // 5. save
    _foodRepository.Update(existingFood);
    return existingFood;    // return the updated food
  }

  public Food? GetFoodById(int foodId)     // null or food obj
  {
    // already returns null if doesn't find.
    return _foodRepository.GetById(foodId);
  }

  public void DeleteFood(int foodId)
  {
    // in the repo, it either deletes it + true or returns false if fails.
    // ie) the repo handles existence check + deletion in 1 step, it is already done.
    var boolDeleted = _foodRepository.Delete(foodId); 

    if (!boolDeleted)
    {
      throw new KeyNotFoundException("Food not found.");
    }
  }
}