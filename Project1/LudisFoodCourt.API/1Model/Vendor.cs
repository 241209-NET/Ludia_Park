using System.ComponentModel.DataAnnotations;

namespace LudisFoodCourt.Api.Model;


public class Vendor 
{
  public int Id { get; set; }
  
  [Required]
  [MaxLength(50)]
  public string Name { get; set; }

  [Required]
  [MaxLength(50)]
  public string FoodType { get; set; }

  // Navigation property: A Vendor can have many Foods
  public ICollection<Food> Foods { get; set; } = new List<Food>();
}


// although not having ? on data type infers not nullable,
// ASP.NET needs [Required] to validate the model