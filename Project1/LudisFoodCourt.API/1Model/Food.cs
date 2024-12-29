using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LudisFoodCourt.Api.Model;


public class Food
{
  public int Id { get; set; }   // entity framework auto knows all Id's are pk's.

  [MaxLength(50)]
  public string Name { get; set; } = "";      // without ? after string, it is auto not nullable.

  [Column(TypeName = "decimal(4, 2)")]
  public decimal Price { get; set; }

  // Foreign Key: Each Food is associated with one Vendor
  public int VendorId { get; set; }  // This is the foreign key property

  // Navigation property: A Food item is related to a single Vendor
  public Vendor Vendor { get; set; } 
}