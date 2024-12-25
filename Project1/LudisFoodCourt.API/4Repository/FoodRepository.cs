using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class FoodRepository : IFoodRepository
{
  private readonly DataContext _dataContext;

  public FoodRepository(DataContext dataContext) => _dataContext = dataContext;

  public Food? GetById(int foodId)
  {
    return _dataContext.Foods.Find(foodId);
  }

}