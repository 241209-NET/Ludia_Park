using LudisFoodCourt.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace LudisFoodCourt.Api.Data;

// public class DataContext : DbContext    // when done with this file do this
public partial class DataContext : DbContext  // when still working on this file, use partial.
{
  public DataContext(){}
  public DataContext(DbContextOptions<DataContext> options) : base(options){}

  public virtual DbSet<Vendor> Vendors { get; set; }
  public virtual DbSet<Vendor> Foods { get; set; }
}

/*
Entity Framework (EF) Core is an ORM.
Uses objects instead of using SQL to interact with database.
EF Core maps your data models (objs) to actual db tables.

DbSet is equivalent to a table.
*/

