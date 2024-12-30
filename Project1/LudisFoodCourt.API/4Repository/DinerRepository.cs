using LudisFoodCourt.Api.Data;
using LudisFoodCourt.Api.Model;

namespace LudisFoodCourt.Api.Repository;

public class DinerRepository : IDinerRepository
{
  private readonly DataContext _dataContext;
  public DinerRepository(DataContext dataContext)
  {
    _dataContext = dataContext;
  } 
    
  public Diner Add(Diner diner)
  {
    _dataContext.Diners.Add(diner);
    _dataContext.SaveChanges();
    return diner;
  }
}