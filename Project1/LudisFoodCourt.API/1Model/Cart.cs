using System.ComponentModel.DataAnnotations.Schema;

namespace LudisFoodCourt.Api.Model;


public class Cart
{
  public int Id { get; set; }
  
  public int DinerId { get; set; }
  
  [Column(TypeName = "decimal(5, 2)")]  
  public decimal Total { get; set; }

  // Navigation property: 1 Cart to 1 Diner
  public Diner Diner { get; set; }
  // Navigation property: 1 Cart to Many Cart Items
  public ICollection<CartItem> CartItems { get; set; }
}