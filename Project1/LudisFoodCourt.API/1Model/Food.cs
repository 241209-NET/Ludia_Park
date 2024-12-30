using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LudisFoodCourt.Api.Model;


public class Food
{
  public int Id { get; set; }   // entity framework auto knows all Id's are pk's.

  [Required]
  [MaxLength(50)]
  public string Name { get; set; }      // without ? after string, it is auto not nullable.

  [Required]
  [Column(TypeName = "decimal(4, 2)")]
  public decimal Price { get; set; }

  [Required]
  public int VendorId { get; set; }  

  // Navigation property: A Food item is related to a single Vendor
  public Vendor Vendor { get; set; } 
}