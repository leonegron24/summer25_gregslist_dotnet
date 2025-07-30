


namespace gregslist_dotnet.Services;

public class CarsService
{
  private readonly CarsRepository _carsRepository;

  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _carsRepository.Create(carData);
    return car;
  }

  internal Car GetCarById(int carId)
  {
    Car car = _carsRepository.GetById(carId);

    if (car == null)
    {
      throw new Exception($"Invalid id: {carId}");
    }

    return car;
  }

  internal List<Car> GetCars()
  {
    List<Car> cars = _carsRepository.GetAll();
    return cars;
  }
}