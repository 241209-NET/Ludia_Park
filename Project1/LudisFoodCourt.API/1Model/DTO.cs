using System.ComponentModel.DataAnnotations;

namespace LudisFoodCourt.Api.DTO;

public class CartItemInputDTO
{
  [Required]
  public int FoodId { get; set; }

  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Qty must be greater than 0.")]
  public int Qty { get; set; } = 1;
}