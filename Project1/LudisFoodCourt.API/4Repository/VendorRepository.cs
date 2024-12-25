using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class VendorRepository : IVendorRepository
{
  private readonly DataContext _dataContext;

  public VendorRepository(DataContext dataContext) => _dataContext = dataContext;

  public IEnumerable<Food> GetAllByVendor(int vendorId)
  {
    return _dataContext.Foods.Where(f => f.VendorId == vendorId).ToList();
  }

  public Food AddFoodToMenu(int vendorId, Food food)
  {
    food.VendorId = vendorId;  // Associate the food with the vendor
    _dataContext.Foods.Add(food);  
    _dataContext.SaveChanges();    
    return food;               
  }

  public Vendor? GetById(int vendorId)
  {
    return _dataContext.Vendors.Find(vendorId);
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

