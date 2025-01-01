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

  public Diner? GetById(int dinerId)      // for 201
  {
    return _dataContext.Diners.Find(dinerId);
  }

  public Diner? Update(Diner diner)
  {
    _dataContext.Diners.Update(diner);
    _dataContext.SaveChanges();
    return diner;
  }
    
  public Diner Add(Diner diner)
  {
    _dataContext.Diners.Add(diner);
    _dataContext.SaveChanges();
    return diner;
  }
}