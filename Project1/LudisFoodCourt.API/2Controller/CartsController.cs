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
      return NotFound(new { message = e.Message });  // returns specific message cuz url not so clear
    }   
  }

  [HttpDelete("{cartId}/foods/{foodId}")]
  public IActionResult DeleteCartItem(int cartId, int foodId)
  {
    try
    {
      _cartItemService.DeleteCartItem(cartId, foodId);  // if this works
      return NoContent(); // returns 204 No Content for successful deletion
    }
    catch (KeyNotFoundException e)  // cart item not found
    {
      return NotFound(new { message = e.Message }); // 404 if food not found
    }
  }

  // [HttpPost("{cartId}/foods")]

  [HttpGet("{cartId}")]
  public IActionResult GetAllCartItems(int cartId)
  {
    var allCartItems = _cartItemService.GetAllCartItems(cartId);
    // cart not found:
    if (allCartItems == null) return NotFound(new { message = "Cart not found." });
    return Ok(allCartItems);
  }
}