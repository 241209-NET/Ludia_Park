using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;

[Route("api/[controller]")]    // in ASP.NET must use double quotes, DO NOT start with /.
[ApiController]                // auto validates model of incoming req's.
public class VendorsController : ControllerBase    
{                                     
  private readonly IVendorService _vendorService;
  public VendorsController(IVendorService vendorService)  // constructor using DI
  {
    _vendorService = vendorService;
  }

  [HttpGet("{vendorId}/foods")]
  public IActionResult GetAllFoodsOfVendor(int vendorId)
  {
    var foodsOfVendor = _vendorService.GetAllFoodsOfVendor(vendorId);
    return Ok(foodsOfVendor);
  }

  [HttpPost("{vendorId}/foods")]
  public IActionResult AddFoodToMenu(int vendorId, Food food)
  {
    var newFood = _vendorService.AddFoodToMenu(vendorId, food);

    return CreatedAtAction(nameof(GetFoodById), new { id = newFood.Id }, newFood);
  }

  [HttpGet("{vendorId}")]

  [HttpGet]
  public IActionResult GetAllVendors()
  {
    var vendors = _vendorService.GetAllVendors();
    return Ok(vendors);
  }

  [HttpPost]
  public IActionResult CreateVendor(Vendor vendor)
  {
    var newVendor = _vendorService.CreateVendor(vendor);
    return CreatedAtAction(nameof(GetVendorById), new { id = newVendor.Id }, newVendor);
  }
}


/*
- [controller] gets replaced by vendors from [Vendors]Controller 
- ControllerBase is for building RESTful api: Ok(), NotFound(), etc.
- Private readonly: The _vendorService field will hold the instance of IVendorService 
  that the controller will use to interact with your business logic layer. 
  It’s marked as readonly, which means it can only be assigned once (in the constructor).
- in order to achieve Created 201 status, use CreatedAtAction w/ these params:
  1) a method to retrieve this new record
  2) route param
  3) new object
- GetFoodById endpoint must be made in order for this Created status to work.
  (even though I don't need it for my app)
*/