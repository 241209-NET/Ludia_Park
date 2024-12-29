

namespace LudisFoodCourt.Api.Model;

public class CartItem   // joint table
{
  public int Id { get; set; }
  public int CartId { get; set; }
  public int FoodId { get; set; }
  public int Qty { get; set; }
  
  // Navigation property: 1 Cart has Many CartItems
  public Cart Cart { get; set; } 
  // Navigation property: 1 Food appears in Many CartItems (since 1 food can appear in multiple carts)
  public Food Food { get; set; }
}