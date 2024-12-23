using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public interface IVendorService
{
  Vendor CreateVendor(Vendor vendor);
  IEnumerable<Vendor> GetAllVendors();
  Food AddFoodToMenu(int vendorId, Food food);
  IEnumerable<Food> GetAllFoodsOfVendor(int vendorId);    
}