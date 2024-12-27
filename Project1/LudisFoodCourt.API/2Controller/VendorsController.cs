using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;


[Route("api/[controller]")]    // in ASP.NET must use double quotes, DO NOT start with /.
[ApiController]                // auto validates model of incoming req's.
public class VendorsController : ControllerBase    
{                                     
  private readonly IVendorService _vendorService;   // declaring private field for interfaces
  private readonly IFoodService _foodService;

  public VendorsController(IVendorService vendorService, IFoodService foodService)  // constructor using DI
  {
    _vendorService = vendorService;   // initialize IVendorService
    _foodService = foodService;       // initialize IFoodService
  }


  [HttpGet("{vendorId}/foods")]
  public IActionResult GetAllFoodsOfVendor(int vendorId)
  {
    // if findVendor not found:
    if (!_vendorService.CheckVendorExists(vendorId)) return NotFound();

    // if found:
    var foodsOfVendor = _vendorService.GetAllFoodsOfVendor(vendorId);
    return Ok(foodsOfVendor);
  }

  [HttpPost("{vendorId}/foods")]
  public IActionResult AddFoodToMenu(int vendorId, Food food)
  {
    // if findVendor not found:
    if (!_vendorService.CheckVendorExists(vendorId)) return NotFound();    

    // if found:
    var newFood = _vendorService.AddFoodToMenu(vendorId, food);
    return CreatedAtAction(nameof(FoodsController.GetFoodById), new { foodId = newFood.Id }, newFood);
  }

  [HttpGet("{vendorId}")]
  public IActionResult GetVendorById(int vendorId)    // for 201 status
  {
    // if findVendor not found:
    if (!_vendorService.CheckVendorExists(vendorId)) return NotFound();    

    var foundVendor = _vendorService.GetVendorById(vendorId);
    return Ok(foundVendor);
  }

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
    return CreatedAtAction(nameof(GetVendorById), new { vendorId = newVendor.Id }, newVendor);
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
- CreatedAtAction(nameof(FoodsController.GetFoodById), new { foodId = newFood.Id }:
  - for new { foodId =...}  it must be foodId because that is what the param of GetFoodById endpoint uses.
*/