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

public class FoodInput2DTO
{
  [Required]
  [MaxLength(50)]
  public string Name { get; set; } 

  [Required]
  [Column(TypeName = "decimal(4, 2)")]
  public decimal Price { get; set; }

  [Required]
  public int VendorId { get; set; }
}

public class FoodOutputDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
}

public class FoodOutput2DTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int VendorId { get; set; }
}

public class VendorOutputDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string FoodType { get; set; }
}