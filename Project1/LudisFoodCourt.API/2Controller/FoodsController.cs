using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;


[Route("api/[controller]")]    
[ApiController]               
public class FoodsController : ControllerBase    
{                                     
  private readonly IFoodService _foodService;
  private readonly IVendorService _vendorService;
  
  public FoodsController(IFoodService foodService, IVendorService vendorService)  // constructor using DI
  {
    _foodService = foodService;
    _vendorService = vendorService;
  }

  [HttpPut("{foodId}/edit")]
  public IActionResult UpdateFood(int foodId, [FromBody] Food food)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    
    // tell service to check if food exists there before updating
    var updatedFood = _foodService.UpdateFood(foodId, food);

    // check each type of null, provide the correct status for each
    if (updatedFood == null) 
    {
      // try getting it first
      var existingFood = _foodService.GetFoodById(foodId);

      // 1. if the VendorId's don't match the original food's VendorId:
      if (existingFood?.VendorId != food.VendorId)  // may be null food
      {
        return Forbid();
      }

      // 2. if vendor doesn't exist:
      bool vendorExists = _vendorService.CheckVendorExists(food.VendorId);
      if (!vendorExists) return NotFound();

      // 3. food not found:
      return NotFound();
    }
    return Ok(updatedFood);
  }

  [HttpGet("{foodId}")]
  public IActionResult GetFoodById(int foodId)    // for 201 status
  {
    var foundFood = _foodService.GetFoodById(foodId);
    
    if (foundFood == null) return NotFound();  
    return Ok(foundFood);
  }

  [HttpDelete("{foodId}")]
  public IActionResult DeleteFood(int foodId)
  {
    try
    {
      _foodService.DeleteFood(foodId);  // if this works
      return NoContent(); // returns 204 No Content for successful deletion
    }
    catch (KeyNotFoundException)  // the special exception thrown by service, msg already written in service.
    {
      return NotFound(); // 404 if food not found
    }
  }
}