namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomesController : ControllerBase
{
    private readonly HomesService _homesService;

    public HomesController(HomesService homesService)
    {
        _homesService = homesService;
    }

    [HttpGet]
    public ActionResult<List<Home>> GetHomes()
    {
        try
        {
            List<Home> homes = _homesService.GetHomes();
            return Ok(homes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
