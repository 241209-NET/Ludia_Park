using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public interface IVendorService
{
  Vendor CreateVendor();
  IEnumerable<Vendor> GetAllVendors();
  // add food to vendor
  
  IEnumerable<Food> GetAllFoodsOfVendor();    // get foods of vendor by id
}