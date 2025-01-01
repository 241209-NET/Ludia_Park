using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;
using Microsoft.EntityFrameworkCore;

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

  public void Delete(CartItem cartItem)
  {
    _dataContext.CartItems.Remove(cartItem);
    _dataContext.SaveChanges();
  }

  public CartItem Add(CartItem cartItem)
  {
    _dataContext.CartItems.Add(cartItem);
    _dataContext.SaveChanges();
    return cartItem;
  }

  public IEnumerable<CartItem>? GetAllByCartId(int cartId)
  {
    return _dataContext.CartItems
                            .Where(c => c.CartId == cartId)
                            .Include(c => c.Food)  // Ensure Food is eagerly loaded
                            .ToList(); 
  }

  public CartItem? GetById(int cartItemId)
  {
    return _dataContext.CartItems.Find(cartItemId);
  }
}