namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;
  private readonly Auth0Provider _auth0Provider;
  public CarsController(CarsService carsService, Auth0Provider auth0Provider)
  {
    _carsService = carsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try
    {
      List<Car> cars = _carsService.GetCars();
      return Ok(cars);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpPost, Authorize]
  public async Task<ActionResult<Car>> CreateCar([FromBody] Car carData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      carData.CreatorId = userInfo.Id;
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}