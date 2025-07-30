
namespace gregslist_dotnet.Services;

public class CarsService
{
  private readonly CarsRepository _carsRepository;

  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }

  internal List<Car> GetCars()
  {
    List<Car> cars = _carsRepository.GetCars();
    return cars;
  }
}