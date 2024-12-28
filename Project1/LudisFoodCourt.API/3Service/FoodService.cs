using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

namespace LudisFoodCourt.Api.Service;

public class FoodService : IFoodService
{
  private readonly IFoodRepository _foodRepository;
  public FoodService(IFoodRepository foodRepository) 
  {
    _foodRepository = foodRepository;
  }

  public Food UpdateFood(int foodId, Food food)
  {
    food.Id = foodId;
    return _foodRepository.Update(food);
  }

  public Food GetFoodById(int foodId)     // for 201
  {
    return _foodRepository.GetById(foodId);
  }

  // helper function to check if exists:
  public bool CheckFoodExists(int foodId)
  {
    var foundFood = _foodRepository.GetById(foodId);
    return foundFood != null;
  }

}