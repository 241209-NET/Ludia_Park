namespace LudisFoodCourt.Api.Model;
using System.ComponentModel.DataAnnotations;


public class Vendor 
{
  public int Id { get; set; }
  
  [MaxLength(100)]
  public string Name { get; set; }

  [MaxLength(100)]
  public string FoodType { get; set; }

  // Navigation property: A Vendor can have many Foods
  public ICollection<Food> Foods { get; set; }
}