using LudisFoodCourt.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;


[Route("api/[controller]")]
[ApiController]
public class DinersController : ControllerBase
{
  private readonly IDinerService _dinerService;
  private readonly ICartService _cartService;

  public DinersController(IDinerService dinerService, ICartService cartService)
  {
    _dinerService = dinerService;
    _cartService = cartService;
  }


  [HttpPost]
  public IActionResult CreateDinerAndCart(Diner diner, Cart cart)
  {
    var newDiner = _dinerService.CreateDiner(diner);
    var newCart = _cartService.CreateCart(cart);

    return CreatedAtAction(nameof(GetDinerById, GetCartById), new { dinerId = newDiner.Id, cartId = newCart.Id }, [newDiner, newCart]);
  }
}