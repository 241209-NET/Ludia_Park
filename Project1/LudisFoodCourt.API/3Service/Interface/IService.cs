using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public interface IVendorService
{
  IEnumerable<Food>? GetAllFoodsOfVendor(int vendorId);  // stay   
  Food? AddFoodToMenu(int vendorId, Food food);   // stay
  Vendor? GetVendorById(int vendorId);           // for 201 status
  IEnumerable<Vendor> GetAllVendors();
  Vendor CreateVendor(Vendor vendor);

  // helper function:
  bool CheckVendorExists(int vendorId);   
}

public interface IFoodService
{
  Food? UpdateFood(int foodId, Food food);
  Food? GetFoodById(int foodId);     // for 201
  void DeleteFood(int foodId);    // for 204 NoContent status, return nothing
}

public interface IDinerService
{
  Diner? GetDinerById(int dinerId);
  Diner CreateDinerAndCart(Diner diner);
}

public interface ICartItemService
{
  void UpdateCartItem(int cartId, int foodId, int qty);
  void DeleteCartItem(int cartId, int foodId);
  IEnumerable<CartItem>? GetAllCartItems(int cartId);
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

- GetAllFoodsOfVendor & AddFoodToMenu must live in Vendor Services due to the url path in vendor controller.
  - however, these methods must use methods from Food repo, since it must talk with Food data.
  - en fin, use vendors services, but use food repo for these 2.

*/