
namespace gregslist_dotnet.Services;

public class HomesService
{
    private readonly HomesRepository _homesRepository;

    public HomesService(HomesRepository homesRepository)
    {
        _homesRepository = homesRepository;
    }

    internal List<Home> GetHomes()
    {
        List<Home> homes = _homesRepository.GetAll();
        return homes;
    }
}