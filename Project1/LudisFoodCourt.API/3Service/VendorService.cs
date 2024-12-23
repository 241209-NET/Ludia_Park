using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public class VendorService : IVendorService
{
  public Food AddFoodToMenu(int vendorId, Food food)
  {
    throw new NotImplementedException();
  }

  public Vendor CreateVendor(Vendor vendor)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<Food> GetAllFoodsOfVendor(int vendorId)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<Vendor> GetAllVendors()
  {
    throw new NotImplementedException();
  }
} 


/*
The VendorService class is the implementation of the IVendorService interface. 
It provides the actual functionality of your application. 
For now, the methods throw NotImplementedException, indicating that the business logic hasn’t been written yet. 
When you implement these methods, this class will contain the logic that interacts with your data layer (like a database) to retrieve and manipulate data.
*/