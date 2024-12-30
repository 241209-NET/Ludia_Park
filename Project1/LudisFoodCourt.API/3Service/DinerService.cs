using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

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

  public Diner? GetDinerById(int dinerId)
  {
    return _dinerRepository.GetById(dinerId);
  }

  public Diner CreateDinerAndCart(Diner diner)
  {
    // 1. create diner + add to repo
    var newDiner = _dinerRepository.Add(diner);

    // 2. create cart, link it to diner
    var newCart = new Cart
    {
      DinerId = newDiner.Id,      // give it the diner's id
      // omit Total, since default starts at 0
    };

    // 3. add cart to repo
    _cartRepository.Add(newCart);

    return newDiner;     
  }
}