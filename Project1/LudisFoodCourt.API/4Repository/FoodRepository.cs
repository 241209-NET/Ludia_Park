using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class FoodRepository : IFoodRepository
{
  private readonly DataContext _dataContext;
  public FoodRepository(DataContext dataContext) => _dataContext = dataContext;

  public IEnumerable<Food> GetAllByVendor(int vendorId) // moved
  {
    return _dataContext.Foods.Where(f => f.VendorId == vendorId).ToList();
  }

  public Food Add(Food food)    // moved and simplified.
  {
    _dataContext.Foods.Add(food);  
    _dataContext.SaveChanges();    
    return food;               
  }

  public Food? GetById(int foodId)            // 201
  {
    return _dataContext.Foods.Find(foodId);
  }

}