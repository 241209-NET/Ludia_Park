using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

namespace LudisFoodCourt.Api.Service;

public class VendorService : IVendorService
{
  private readonly IVendorRepository _vendorRepository;
  private readonly IFoodRepository _foodRepository;

  public VendorService(IVendorRepository vendorRepository, IFoodRepository foodRepository) 
  {
    _vendorRepository = vendorRepository;
    _foodRepository = foodRepository;
  }

  public IEnumerable<Food> GetAllFoodsOfVendor(int vendorId)
  {
    return _vendorRepository.GetAllByVendor(vendorId);
  }

  public Food AddFoodToMenu(int vendorId, Food food)
  {
    return _vendorRepository.AddFoodToMenu(vendorId, food);  
  }

  public Vendor? GetVendorById(int vendorId)         // for 201 status
  {
    return _vendorRepository.GetById(vendorId);
  }

  public IEnumerable<Vendor> GetAllVendors()
  {
    return _vendorRepository.GetAll();
  }

  public Vendor CreateVendor(Vendor vendor)
  {
    return _vendorRepository.Add(vendor);
  }
} 


/*
The VendorService class is the implementation of the IVendorService interface. 
It provides the actual functionality of your application. 
For now, the methods throw NotImplementedException, indicating that the business logic hasn’t been written yet. 
When you implement these methods, this class will contain the logic that interacts with your data layer (like a database) to retrieve and manipulate data.
*/