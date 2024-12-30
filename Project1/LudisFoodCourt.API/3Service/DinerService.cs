

namespace LudisFoodCourt.Api.Service;

public class DinerService : IDinerService
{
  private readonly IDinerRepository _dinerRepository;
  private readonly ICartRepository _cartRepository;

  public DinerService(IDinerRepository dinerRepository, ICartRepository cartRepository)
  {
    _dinerRepository = dinerRepository;
    _cartRepository = cartRepository;
  }

  public 
}