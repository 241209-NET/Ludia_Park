namespace LudisFoodCourt.Api.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vendor 
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  
  [Required]
  [MaxLength(100)]
  public string Name { get; set; }

  [Required]
  [MaxLength(100)]
  public string FoodType { get; set; }

  // Navigation property: A Vendor can have many Foods
  public ICollection<Food> Foods { get; set; }
}