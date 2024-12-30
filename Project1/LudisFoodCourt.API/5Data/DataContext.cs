using LudisFoodCourt.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace LudisFoodCourt.Api.Data;

// public class DataContext : DbContext    // when done with this file do this
public partial class DataContext : DbContext  // when still working on this file, use partial.
{
  public DataContext(){}
  public DataContext(DbContextOptions<DataContext> options) : base(options){}

  public virtual DbSet<Vendor> Vendors { get; set; }
  public virtual DbSet<Food> Foods { get; set; }
  public virtual DbSet<Diner> Diners { get; set; }
  public virtual DbSet<Cart> Carts { get; set; }
  public virtual DbSet<CartItem> CartItems { get; set; }

  // for 1 to 1, this override is needed or else cannot migrate.
  // EF needs explicit instructions on which entity holds the foreign key
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder); // preserve any default behavior of the base class, best to keep this

    // 1-to-1 relationship between Diner and Cart
    modelBuilder.Entity<Diner>()
      .HasOne(d => d.Cart)           // Diner has one Cart
      .WithOne(c => c.Diner)         // Cart has one Diner
      .HasForeignKey<Diner>(d => d.CartId)   // Foreign key is on Diner
      .IsRequired();  // Makes sure the CartId is required for Diner 
  
    modelBuilder.Entity<Cart>()
      .HasOne(c => c.Diner)         // Cart has one Diner
      .WithOne(d => d.Cart)         // Diner has one Cart
      .HasForeignKey<Cart>(c => c.DinerId)  // Foreign key is on Cart
      .IsRequired(); // This also ensures Cart is required for Diner

    // the recommended way to add a unique constraint to a column:
    modelBuilder.Entity<Diner>()
      .HasIndex(d => d.Name)
      .IsUnique();
  }
}

/*
Entity Framework (EF) Core is an ORM.
Uses objects instead of using SQL to interact with database.
EF Core maps your data models (objs) to actual db tables.

DbSet is equivalent to a table.
*/

