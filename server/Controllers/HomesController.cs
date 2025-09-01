namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomesController : ControllerBase
{
    private readonly HomesService _homesService;
    private readonly Auth0Provider _auth0Provider;

    public HomesController(HomesService homesService, Auth0Provider auth0Provider)
    {
        _homesService = homesService;
        _auth0Provider = auth0Provider;
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

    [HttpGet("{homeId}")]
    public ActionResult<Home> GetHomeById(int homeId)
    {
        try
        {
            Home home = _homesService.GetHomeBydId(homeId);
            return Ok(home);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Home>> CreateHome([FromBody] Home homeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            homeData.CreatorId = userInfo.Id;
            Home home = _homesService.CreateHome(homeData);
            return Ok(home);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{homeId}")]
    [Authorize]
    public ActionResult<string> DeleteHome(int homeId)
    {
        try
        {
            string message = _homesService.DeleteHome(homeId);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{homeId}")]
    [Authorize]
    public async Task<ActionResult<Home>> UpdateHome(int homeId, [FromBody] Home homeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Home home = _homesService.UpdateHome(homeId, homeData, userInfo);
            return Ok(home);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
