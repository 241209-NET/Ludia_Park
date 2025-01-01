using LudisFoodCourt.Api.Service;
using LudisFoodCourt.Api.DTO; 
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

  [HttpPost("{cartId}/foods")]
  public IActionResult CreateCartItem(int cartId, [FromBody] CartItemInputDTO cartItemInputDto)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    try
    {
      // create the cartItem first
      var newCartItem = _cartItemService.CreateCartItem(cartId, cartItemInputDto.FoodId, cartItemInputDto.Qty);
      
      // map it:
      var cartItemDto = new CartItemOutputDTO
      {
        FoodId = newCartItem.FoodId,
        Name = newCartItem.Food.Name,
        Qty = newCartItem.Qty
      };
      return Ok(cartItemDto);    // can make a new endpoint GetCartItemById for CreatedAtAction
    }
    catch (KeyNotFoundException e)
    { // cart not found or food not found
      return NotFound(new { message = e.Message });
    };
  }

  [HttpGet("{cartId}")]
  public IActionResult GetAllCartItems(int cartId)
  {
    var allCartItems = _cartItemService.GetAllCartItems(cartId);
    // cart not found:
    if (allCartItems == null) return NotFound(new { message = "Cart not found." });

    // map it:
    var cartItemDtos = allCartItems.Select(c => new CartItemOutputDTO
    {
      FoodId = c.FoodId,
      Name = c.Food?.Name,
      Qty = c.Qty
    }).ToList();

    return Ok(cartItemDtos);
  }
}