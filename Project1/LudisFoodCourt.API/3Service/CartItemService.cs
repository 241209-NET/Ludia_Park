using LudisFoodCourt.Api.Model;
using LudisFoodCourt.Api.Repository;

namespace LudisFoodCourt.Api.Service;

public class CartItemService : ICartItemService
{
  private readonly ICartItemRepository _cartItemRepository;
  private readonly ICartRepository _cartRepository;
  private readonly IFoodRepository _foodRepository;

  public CartItemService(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IFoodRepository foodRepository)
  {
    _cartItemRepository = cartItemRepository;
    _cartRepository = cartRepository;
    _foodRepository = foodRepository;
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

  public void DeleteCartItem(int cartId, int foodId)
  {
    var existingCartItem = _cartItemRepository.GetByIdAndFoodId(cartId, foodId);
    if (existingCartItem != null)
    {
      _cartItemRepository.Delete(existingCartItem);
    }
    else
    {
      throw new KeyNotFoundException("CartItem not found.");
    }
  }

  public CartItem CreateCartItem(int cartId, int foodId, int qty)
  {
    // 1. check if cart exists
    var cart = _cartRepository.GetById(cartId);
    if (cart == null)
    {
      throw new KeyNotFoundException("Cart not found.");
    }

    // 2. check if food exists
    var food = _foodRepository.GetById(foodId);
    if (food == null)
    {
      throw new KeyNotFoundException("Food not found.");
    }

    // 3. create cartItem record
    var newCartItem = new CartItem
    {
      CartId = cartId,
      FoodId = foodId,
      Qty = qty
    };

    _cartItemRepository.Add(newCartItem);

    return _cartItemRepository.GetById(newCartItem.Id);
  }

  public IEnumerable<CartItem>? GetAllCartItems(int cartId)
  {
    // 1. check if cart exists
    var cart = _cartRepository.GetById(cartId);
    if (cart == null) return null;
    
    // 2. if exists, get all items.
    return _cartItemRepository.GetAllByCartId(cartId);
  }

  public CartItem? GetById(int cartItemId)
  {
    return _cartItemRepository.GetById(cartItemId);
  }
}