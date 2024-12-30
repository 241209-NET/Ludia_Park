using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public interface IVendorRepository
{
  Vendor? GetById(int vendorId);       // for 201 status
  IEnumerable<Vendor> GetAll(); // Get all vendors
  Vendor Add(Vendor vendor);  // creating a new vendor
}

public interface IFoodRepository
{
  IEnumerable<Food>? GetAllByVendor(int vendorId);   // moved
  Food? Add(Food food);    // moved.  this can be simple now, service layer takes care of setting correct VendorId.
  Food? Update(Food food);
  Food? GetById(int foodId);     // for 201
  bool Delete(int foodId);    // repo is bool but service is void
}

public interface IDinerRepository
{
  Diner? GetById(int dinerId);    // for 201
  Diner Add(Diner diner);
}

public interface ICartRepository
{
  Cart Add(Cart cart);
}
