using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class CartRepository : ICartRepository
{
  private readonly DataContext _dataContext;
  public CartRepository(DataContext dataContext)
  {
    _dataContext = dataContext;
  }

  public Cart Add(Cart cart)
  {
    _dataContext.Carts.Add(cart);
    _dataContext.SaveChanges();
    return cart;
  }
}