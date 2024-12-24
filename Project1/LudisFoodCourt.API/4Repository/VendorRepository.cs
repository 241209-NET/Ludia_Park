using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class VendorRepository : IVendorRepository
{
  // we need a db to work with
  private readonly DataContext _dataContext;

  public VendorRepository(DataContext dataContext) => _dataContext = dataContext;

  public IEnumerable<Food> GetAllByVendor(int vendorId)
  {
    return _dataContext.Foods.Where(f => f.VendorId == vendorId).ToList();
  }

  public Food AddFoodToMenu(int vendorId, Food food)
  {
    food.VendorId = vendorId;  // Associate the food with the vendor
    _dataContext.Foods.Add(food);  // Add the food to the Foods table
    _dataContext.SaveChanges();    // Save the changes to the database
    return food;               // Return the added food item
  }

  public IEnumerable<Vendor> GetAll()
  {
    return _dataContext.Vendors.ToList();
  }

  public Vendor Add(Vendor vendor)
  {
    _dataContext.Vendors.Add(vendor);
    _dataContext.SaveChanges();
    return vendor;
  }
}

