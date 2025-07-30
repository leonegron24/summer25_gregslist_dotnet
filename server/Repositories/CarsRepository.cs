
using gregslist_dotnet.Interfaces;

namespace gregslist_dotnet.Repositories;

public class CarsRepository : IRepository<Car>
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Car Create(Car carData)
  {
    string sql = @"
    INSERT INTO
    cars (
      make,
      model,
      year,
      price,
      img_url,
      description,
      engine_type,
      color,
      mileage,
      has_clean_title,
      creator_id
    )
    VALUES (
      @Make,
      @Model,
      @Year,
      @Price,
      @ImgUrl,
      @Description,
      @EngineType,
      @Color,
      @Mileage,
      @HasCleanTitle,
      @CreatorId
    );
    
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();";

    Car car = _db.Query<Car>(sql, carData).SingleOrDefault();

    return car;
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