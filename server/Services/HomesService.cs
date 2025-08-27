

namespace gregslist_dotnet.Services;

public class HomesService
{
    private readonly HomesRepository _homesRepository;

    public HomesService(HomesRepository homesRepository)
    {
        _homesRepository = homesRepository;
    }

    internal Home CreateHome(Home homedata)
    {
        Home home = _homesRepository.Create(homedata);
        return home;
    }

    internal string DeleteHome(int homeId)
    {
        _homesRepository.Delete(homeId);
        return $"Deleting car with Id: {homeId}";
    }

    internal Home GetHomeBydId(int homeId)
    {
        Home home = _homesRepository.GetById(homeId);

        if (home == null)
        {
            throw new Exception("Invalid home Id: " + homeId);
        }
        return home;
    }

    internal List<Home> GetHomes()
    {
        List<Home> homes = _homesRepository.GetAll();
        return homes;
    }
}