using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;


[Route("api/[controller]")]
[ApiController]
public class DinersController : ControllerBase
{
  private readonly IDinerService _dinerService;

  public DinersController(IDinerService dinerService)
  {
    _dinerService = dinerService;
  }


  [HttpPost]
  public IActionResult CreateDinerAndCart([FromBody] Diner diner)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var newDiner = _dinerService.CreateDinerAndCart(diner);

    return CreatedAtAction(nameof(GetDinerById), new { dinerId = newDiner.Id }, newDiner);
  }
}