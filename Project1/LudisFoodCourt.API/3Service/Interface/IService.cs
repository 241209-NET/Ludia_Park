using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public interface IVendorService
{
  IEnumerable<Food> GetAllFoodsOfVendor(int vendorId);    
  Food AddFoodToMenu(int vendorId, Food food);
  IEnumerable<Vendor> GetAllVendors();
  Vendor CreateVendor(Vendor vendor);
}

/*
- Separation of concerns: 
The interface separates the definition of the service (the "what" the service does) 
from its actual implementation (the "how" the service works).
- Testing:
Interfaces make it easier to mock dependencies during unit testing. 
Ex) in your unit tests, you can mock IVendorService without needing to worry about the actual database or business logic.
Loose coupling:
Using interfaces decouples the VendorsController from the actual implementation of the service. 
The controller only depends on the interface, not the concrete class. 
This makes the system more flexible and maintainable. 
You can change the implementation of VendorService later without modifying the controller, as long as the contract (the interface) stays the same.
*/