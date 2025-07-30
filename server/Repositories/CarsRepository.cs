
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
    
    SELECT
    cars.*,
    accounts.*
    FROM cars
    JOIN accounts ON cars.creator_id = accounts.id
    WHERE cars.id = LAST_INSERT_ID();";

    Car newCar = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }, carData).SingleOrDefault();

    return newCar;
  }

  public void Delete(int carId)
  {
    throw new NotImplementedException();
  }

  public Car GetById(int carId)
  {
    string sql = @"
    SELECT
    cars.*,
    accounts.*
    FROM cars
    JOIN accounts ON cars.creator_id = accounts.id
    WHERE cars.id = @CarId;";

    Car foundCar = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }, new { CarId = carId }).SingleOrDefault();

    return foundCar;
  }

  public void Update(Car updateData)
  {
    string sql = @"
    UPDATE cars
    SET
    img_url = @ImgUrl,
    description = @Description,
    price = @Price,
    engine_type = @EngineType,
    mileage = @Mileage,
    color = @Color,
    has_clean_title = @HasCleanTitle
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, updateData);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows are now updated and that is bad!");
    }
  }

  public List<Car> GetAll()
  {
    string sql = @"
    SELECT
    cars.*,
    accounts.*
    FROM cars
    JOIN accounts ON cars.creator_id = accounts.id
    ORDER BY cars.created_at ASC;";

    List<Car> cars = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }).ToList();

    return cars;
  }
}