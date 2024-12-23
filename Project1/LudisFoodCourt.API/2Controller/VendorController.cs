using LudisFoodCourt.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;

[Route("api/[controller]")]    // in ASP.NET must use double quotes, DO NOT start with /.
[ApiController]   // auto validates model of incoming req's.
public class VendorsController : ControllerBase    // [controller] gets replaced by vendors from VendorsController 
{                                     // ControllerBase is for building RESTful api: Ok(), NotFound(), etc.

  // [HttpPost("{vendorId}/foods")]
  // public IActionResult AddFoodToMenu(Food newFood)
  // {
  //   var createdFood = 
  //   return Created(createdFood);
  // }

  [HttpGet]
  public IActionResult GetAllVendors()
  {
    return Ok("list of vendors put in later");
  }

  // [HttpPost]
  // public IActionResult CreateVendor(Vendor newVendor)
  // {
  //   var createdPet = 
  //   return Created(createdPet);
  // }
}