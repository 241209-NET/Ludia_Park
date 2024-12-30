

using System.ComponentModel.DataAnnotations;

namespace LudisFoodCourt.Api.Model;

public class CartItem   // joint table
{
  public int Id { get; set; }

  [Required]
  public int CartId { get; set; }

  [Required]
  public int FoodId { get; set; }

  [Required]
  public int Qty { get; set; }
  
  // Navigation property: 1 Cart has Many CartItems
  public Cart Cart { get; set; } 
  // Navigation property: 1 Food appears in Many CartItems (many foods to many carts)
  public Food Food { get; set; }
}