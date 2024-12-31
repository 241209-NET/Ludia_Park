using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class CartItemRepository : ICartItemRepository
{
  private readonly DataContext _dataContext;
  public CartItemRepository(DataContext dataContext)
  {
    _dataContext = dataContext;
  }

  public CartItem? GetByIdAndFoodId(int cartId, int foodId)
  {
    return _dataContext.CartItems.FirstOrDefault(r => r.CartId == cartId && r.FoodId == foodId);
  }   // FirstOrDefault for querying multiple instead of Find

  public void Update(CartItem cartItem)
  {
    _dataContext.CartItems.Update(cartItem);
    _dataContext.SaveChanges();
  }
}