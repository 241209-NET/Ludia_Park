using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Service;
using LudisFoodCourt.Api.DTO;
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

  [HttpGet("{dinerId}")]
  public IActionResult GetDinerById(int dinerId)    // for 201
  {
    var foundDiner = _dinerService.GetDinerById(dinerId);

    if (foundDiner == null) return NotFound();
    return Ok(foundDiner);
  }

  [HttpPost]
  public IActionResult CreateDinerAndCart([FromBody] DinerInputDTO dinerInputDTO)
  {
    // Automatically checks if the model is valid (based on annotations like [Required], [MaxLength], etc.)
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    // Map the DTO to the Diner model
    var diner = new Diner
    {
      Name = dinerInputDTO.Name
    };

    var newDiner = _dinerService.CreateDinerAndCart(diner);

    // Map it back from model to output dto
    var dinerDto = new DinerOutputDTO
    {
      Id = newDiner.Id,
      Name = newDiner.Name,
      CartId = newDiner.CartId
    };

    return CreatedAtAction(nameof(GetDinerById), new { dinerId = newDiner.Id }, dinerDto);
  }
}