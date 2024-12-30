using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class VendorRepository : IVendorRepository
{
  private readonly DataContext _dataContext;
  public VendorRepository(DataContext dataContext) 
  {
    _dataContext = dataContext;
  }

  public Vendor? GetById(int vendorId)        // 201
  {
    return _dataContext.Vendors.Find(vendorId);
  }

  public IEnumerable<Vendor> GetAll()
  {
    return _dataContext.Vendors.ToList();
  }

  public Vendor Add(Vendor vendor)
  {
    _dataContext.Vendors.Add(vendor);
    _dataContext.SaveChanges();
    return vendor;
  }
}

