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
  // the rest
  public Food? GetFoodById(int foodId)     // for 201
  {
    return _foodRepository.GetById(foodId);
  }

}