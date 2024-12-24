using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class VendorRepository : IVendorRepository
{
  public IEnumerable<Food> GetAllByVendor(int vendorId)
  {
    throw new NotImplementedException();
  }

  public Food AddFoodToMenu(int vendorId, Food food)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<Vendor> GetAll()
  {
    throw new NotImplementedException();
  }

  public Vendor Add(Vendor vendor)
  {
    throw new NotImplementedException();
  }
}

