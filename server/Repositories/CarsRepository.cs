
using gregslist_dotnet.Interfaces;

namespace gregslist_dotnet.Repositories;

public class CarsRepository : IRepository<Car>
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Car Create(Car updateData)
  {
    throw new NotImplementedException();
  }

  public void Delete(int carId)
  {
    throw new NotImplementedException();
  }



  public Car GetById(int carId)
  {
    throw new NotImplementedException();
  }

  public Car Update(Car updateData)
  {
    throw new NotImplementedException();
  }

  public List<Car> GetAll()
  {
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();

    return cars;
  }
}