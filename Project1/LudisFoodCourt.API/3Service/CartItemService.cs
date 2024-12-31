using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

namespace LudisFoodCourt.Api.Service;

public class CartItemService : ICartItemService
{
  private readonly ICartItemRepository _cartItemRepository;

  public CartItemService(ICartItemRepository cartItemRepository)
  {
    _cartItemRepository = cartItemRepository;
  }
  
  public void UpdateCartItem(int cartId, int foodId, int qty)
  {
    var existingCartItem = _cartItemRepository.GetByIdAndFoodId(cartId, foodId);
    if (existingCartItem != null)
    {
      existingCartItem.Qty = qty;
      _cartItemRepository.Update(existingCartItem);
    }
    else 
    { // must throw exception instead of returning null cuz of void return
      throw new KeyNotFoundException("CartItem not found.");
    } 
  }

  // helper function to check if vendor exists:
  public bool CheckCartItemExists(int cartId, int foodId)
  {
    var foundCartItem = _cartItemRepository.GetByIdAndFoodId(cartId, foodId);
    return foundCartItem != null;
  }
}