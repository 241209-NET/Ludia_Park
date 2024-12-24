using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public interface IVendorRepository
{
  IEnumerable<Food> GetAllByVendor(int vendorId);
  Food AddFoodToMenu(int vendorId, Food food);  // this is a custom one: add a food to a specific vendor
  Vendor GetById(int vendorId);       // for 201 status
  IEnumerable<Vendor> GetAll(); // Get all vendors
  Vendor Add(Vendor vendor);  // creating a new vendor
}

// Food Add(Food food);  // this is just plain add food to all foods.