using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LudisFoodCourt.Api.Model;


public class Cart
{
  public int Id { get; set; }
  
  [Required]
  public int DinerId { get; set; }
  
  [Required]
  [Column(TypeName = "decimal(5, 2)")]  
  public decimal Total { get; set; } = 0;

  // Navigation property: 1 Cart to 1 Diner
  public Diner Diner { get; set; }
  // Navigation property: Many to Many with Foods via CartItems
  public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}