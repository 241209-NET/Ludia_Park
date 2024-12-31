using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LudisFoodCourt.Api.DTO;

public class CartItemInputDTO
{
  [Required]
  public int FoodId { get; set; }

  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Qty must be greater than 0.")]
  public int Qty { get; set; } = 1;
}

public class FoodInputDTO
{
  [Required]
  [MaxLength(50)]
  public string Name { get; set; } 

  [Required]
  [Column(TypeName = "decimal(4, 2)")]
  public decimal Price { get; set; }
}