


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

  internal string DeleteCar(int carId, Account userInfo)
  {
    Car carToDelete = GetCarById(carId);

    if (carToDelete.CreatorId != userInfo.Id)
    {
      throw new Exception($"THAT AIN'T YOUR CAR {userInfo.Name.ToUpper()}! 🚓🚓🚓🚓🚓");
    }

    _carsRepository.Delete(carId);

    return $"Your {carToDelete.Year} {carToDelete.Make} {carToDelete.Model} has been deleted!";
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

  internal Car UpdateCar(int carId, Car carUpdateData, Account userInfo)
  {
    Car originalCar = GetCarById(carId);

    if (originalCar.CreatorId != userInfo.Id)
    {
      throw new Exception($"THIS AIN'T YOUR CAR, {userInfo.Name.ToUpper()}!");
    }

    originalCar.ImgUrl = carUpdateData.ImgUrl ?? originalCar.ImgUrl;
    originalCar.Description = carUpdateData.Description ?? originalCar.Description;
    originalCar.Color = carUpdateData.Color ?? originalCar.Color;
    originalCar.EngineType = carUpdateData.EngineType ?? originalCar.EngineType;
    // NOTE make sure bools or ints are nullable in your model
    originalCar.Mileage = carUpdateData.Mileage ?? originalCar.Mileage;
    originalCar.Price = carUpdateData.Price ?? originalCar.Price;
    originalCar.HasCleanTitle = carUpdateData.HasCleanTitle ?? originalCar.HasCleanTitle;

    _carsRepository.Update(originalCar);

    return originalCar;
  }
}