using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using LudisFoodCourt.Api.DTO;
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
    var foodsOfVendor = _vendorService.GetAllFoodsOfVendor(vendorId);
    // if findVendor not found:
    if (foodsOfVendor == null)
    {
      return NotFound("Vendor not found");  // custom NotFound msg
    }

    // map the list of foods to FoodDto:
    var foodDtos = foodsOfVendor.Select(f => new FoodOutputDTO
    {
      Id = f.Id,
      Name = f.Name,
      Price = f.Price
    }).ToList();

    return Ok(foodDtos);
  }

  [HttpPost("{vendorId}/foods")]     
  public IActionResult AddFoodToMenu(int vendorId, [FromBody] FoodInputDTO foodInputDTO)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    // create the new food:
    var createdFood = new Food
    {
      Name = foodInputDTO.Name,
      Price = foodInputDTO.Price,
      VendorId = vendorId // We get the vendorId from the route
    };

    var newFood = _vendorService.AddFoodToMenu(vendorId, createdFood);

    // if vendor not found:
    if (newFood == null)
    {
      return NotFound("Vendor not found");  // custom NotFound msg
    }

    // Map the createdFood object to FoodOutput2DTO
    var foodDto = new FoodOutput2DTO
    {
      Id = newFood.Id,
      Name = newFood.Name,
      Price = newFood.Price,
      VendorId = newFood.VendorId // Include VendorId in the response
    };

    return Ok(foodDto);   // note to self: CreatedAtAction doesn't work cross-controllers
  }

  [HttpGet("{vendorId}")]
  public IActionResult GetVendorById(int vendorId)    // for 201 status
  {
    var foundVendor = _vendorService.GetVendorById(vendorId);

    // if vendor not found:
    if (foundVendor == null) return NotFound();    // no need for custom, since this is plain vendor. 
    return Ok(foundVendor);
  }

  [HttpGet]
  public IActionResult GetAllVendors()
  {
    var vendors = _vendorService.GetAllVendors();

    // Map vendor data to vendor dto:
    var vendorDtos = vendors.Select(v => new VendorOutputDTO
    {
      Id = v.Id,
      Name = v.Name,
      FoodType = v.FoodType
    });

    return Ok(vendorDtos);
  }

  [HttpPost]
  public IActionResult CreateVendor([FromBody] Vendor vendor)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var newVendor = _vendorService.CreateVendor(vendor);

    // map it
    var vendorDto = new VendorOutputDTO
    {
      Id = newVendor.Id,
      Name = newVendor.Name,
      FoodType = newVendor.FoodType
    };

    return CreatedAtAction(nameof(GetVendorById), new { vendorId = newVendor.Id }, vendorDto);
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
- all requests with data in req body must include [FromBody]: POST, PUT, PATCH.  
  - the incoming JSON will be deserialized into the Diner obj, and u can work with it.
  - later on, when you have form data in front-end, u omit [FromBody].
*/