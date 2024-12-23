using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public interface IVendorService
{
  IEnumerable<Food> GetAllFoodsOfVendor(int vendorId);    
  Food AddFoodToMenu(int vendorId, Food food);
  IEnumerable<Vendor> GetAllVendors();
  Vendor CreateVendor(Vendor vendor);
}