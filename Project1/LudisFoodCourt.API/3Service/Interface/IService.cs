using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Service;

public interface IVendorService
{
  Vendor CreateVendor();
  IEnumerable<Vendor> GetAllVendors();
}