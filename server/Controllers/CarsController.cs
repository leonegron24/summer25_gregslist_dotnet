namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  [HttpGet]
  public string Test()
  {
    return "It works!";
  }
}