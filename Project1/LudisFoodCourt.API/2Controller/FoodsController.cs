using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;


[Route("api/[controller]")]    
[ApiController]               
public class FoodsController : ControllerBase    
{                                     
  private readonly IFoodService _foodService;
  
  public FoodsController(IFoodService foodService)  // constructor using DI
  {
    _foodService = foodService;
  }

  [HttpPut("{foodId}/edit")]
  public IActionResult UpdateFood(int foodId, Food food)
  {
    // if findFood not found:
    if (!_foodService.CheckFoodExists(foodId)) return NotFound();

    // if found: 
    var updatedFood = _foodService.UpdateFood(foodId, food);
    return Ok(updatedFood);
  }

  [HttpGet("{foodId}")]
  public IActionResult GetFoodById(int foodId)    // for 201 status
  {
    var foundFood = _foodService.GetFoodById(foodId);
    
    // Explicitly check if food exists:
    if (foundFood == null) return NotFound();  // returns HTTP 404 Not Found
    
    return Ok(foundFood);
  }

  // [HttpDelete("{foodId}")]
  // public IActionResult DeleteFood(int foodId)
  // {
  //   //////////
  // }

}