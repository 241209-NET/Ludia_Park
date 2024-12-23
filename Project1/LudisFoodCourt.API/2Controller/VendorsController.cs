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
  public IActionResult GetFoodsOfVendor(int vendorId)
  {
    var foodsOfVendor = _vendorService.GetAllFoodsOfVendor(vendorId);
    return Ok(foodsOfVendor);
  }

  // [HttpPost("{vendorId}/foods")]
  // public IActionResult AddFoodToMenu(int vendorId, Food food)
  // {
  //   var newFood = 
  //   return Created(newFood);
  // }

  [HttpGet]
  public IActionResult GetAllVendors()
  {
    return Ok("list of vendors put in later");
    // var vendors = _vendorService.GetAllVendors();
    // return Ok(vendors);
  }

  // [HttpPost]
  // public IActionResult CreateVendor(Vendor vendor)
  // {
  //   var newVendor = 
  //   return Created(newVendor);
  // }
}


/*
- [controller] gets replaced by vendors from [Vendors]Controller 
- ControllerBase is for building RESTful api: Ok(), NotFound(), etc.
- Private readonly: The _vendorService field will hold the instance of IVendorService 
  that the controller will use to interact with your business logic layer. 
  It’s marked as readonly, which means it can only be assigned once (in the constructor).
*/