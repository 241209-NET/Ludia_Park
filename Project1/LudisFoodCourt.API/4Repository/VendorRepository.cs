using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

// i just added this, i need to understand this, how it connects.
public class VendorRepository : IVendorRepository
{
    private readonly VendorContext _context;  // Assuming you're using EF Core and VendorContext is your DbContext

    public VendorRepository(VendorContext context)
    {
        _context = context;
    }

    public IEnumerable<Food> GetAllByVendor(int vendorId)
    {
        return _context.Foods.Where(f => f.VendorId == vendorId).ToList();
    }

    public Food AddFoodToMenu(int vendorId, Food food)
    {
        food.VendorId = vendorId;  // Associate the food with the vendor
        _context.Foods.Add(food);  // Add the food to the Foods table
        _context.SaveChanges();    // Save the changes to the database
        return food;               // Return the added food item
    }

    public IEnumerable<Vendor> GetAll()
    {
        return _context.Vendors.ToList();
    }

    public Vendor Add(Vendor vendor)
    {
        _context.Vendors.Add(vendor);
        _context.SaveChanges();
        return vendor;  // Return the created vendor
    }

    IEnumerable<Food> IVendorRepository.GetAllByVendor(int vendorId)
    {
        throw new NotImplementedException();
    }

    public Food AddFoodToMenu(int vendorId, Food food)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Vendor> IVendorRepository.GetAll()
    {
        throw new NotImplementedException();
    }

    public Vendor Add(Vendor vendor)
    {
        throw new NotImplementedException();
    }
}