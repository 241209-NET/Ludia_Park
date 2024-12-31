using LudisFoodCourt.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;


[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
  private readonly ICartItemService _cartItemService;

  public CartsController(ICartItemService cartItemService)
  {
    _cartItemService = cartItemService;
  }

  [HttpPut("{cartId}/foods/{foodId}")]
  public IActionResult UpdateCartItem(int cartId, int foodId, [FromBody] int qty)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    try
    {
      _cartItemService.UpdateCartItem(cartId, foodId, qty);
      return NoContent();   // 204 successful, but no body return
    }
    catch (KeyNotFoundException e)  // cart item was not found
    {
      return NotFound(new { message = e.Message});  // returns specific message cuz url not so clear
    }   
  }
}