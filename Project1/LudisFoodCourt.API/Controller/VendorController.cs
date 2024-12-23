using Microsoft.AspNetCore.Mvc;

namespace LudisFoodCourt.Api.Controller;

[Route("/vendors")]
[ApiController]   // auto validates model of incoming req's.
public class VendorController : ControllerBase
{
  [HttpGet]
  public IActionResult GetAllVendors()
  {
    return Ok("list of vendors put in later");
  }
}