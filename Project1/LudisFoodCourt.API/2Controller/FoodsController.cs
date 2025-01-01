using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using LudisFoodCourt.Api.DTO;
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
  public IActionResult UpdateFood(int foodId, [FromBody] FoodInput2DTO foodInput2DTO)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    // Get the existing food
    var existingFood = _foodService.GetFoodById(foodId);

    if (existingFood.VendorId != foodInput2DTO.VendorId)
    {
      return Forbid(); // The VendorId in the DTO doesn't match the existing food's VendorId
    }

    // Check if the vendor exists
    bool vendorExists = _vendorService.CheckVendorExists(foodInput2DTO.VendorId);
    if (!vendorExists)
    {
      return NotFound("Vendor not found");
    }

    // Map from input dto to Food entity
    var foodToUpdate = new Food
    {
      Id = foodId,  // Keep the original ID
      Name = foodInput2DTO.Name,
      Price = foodInput2DTO.Price,
      VendorId = foodInput2DTO.VendorId
    };

    // use the full obj to UpdateFood method in service
    var updatedFood = _foodService.UpdateFood(foodId, foodToUpdate);

    if (updatedFood == null)
    {
      return NotFound("Food not found"); 
    }

    // Map the updatedFood obj to FoodOutput2DTO
    var foodDto = new FoodOutput2DTO
    {
      Id = updatedFood.Id,
      Name = updatedFood.Name,
      Price = updatedFood.Price,
      VendorId = updatedFood.VendorId
    };

    // Return the updated food
    return Ok(foodDto);
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