using System.ComponentModel.DataAnnotations;

namespace LudisFoodCourt.Api.Model;


public class Diner
{
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string Name { get; set; }

  [Required]
  public int CartId { get; set; }

  // Navigation property: 1 Diner to 1 Cart
  public Cart Cart { get; set; } 
}