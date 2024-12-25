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

  [HttpGet("{foodId}")]
  public IActionResult GetFoodById(int foodId)    // for 201 status
  {
    var foundFood = _foodService.GetFoodById(foodId);
    if (foundFood == null) return NotFound();
    return Ok(foundFood);
  }

}