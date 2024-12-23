namespace LudisFoodCourt.Api.Model;
using System.ComponentModel.DataAnnotations;

public class Vendor 
{
  [Key]
  public int Id { get; set; }
  
  [Required]
  [MaxLength(100)]
  public string Name { get; set; }

  [Required]
  [MaxLength(100)]
  public string FoodType { get; set; }
}