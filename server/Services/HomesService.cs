

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
        return $"Deleting home with Id: {homeId}";
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

    internal Home UpdateHome(int homeId, Home homeData, Account userInfo)
    {
        Home homeToUpdate = GetHomeBydId(homeId);

        if (homeToUpdate.CreatorId != userInfo.Id)
        {
            throw new Exception($"You cannot update another users home, {userInfo.Name}!");
        }

        homeToUpdate.Bathrooms = homeData.Bathrooms ?? homeToUpdate.Bathrooms;
        homeToUpdate.Bedrooms = homeData.Bedrooms ?? homeToUpdate.Bedrooms;
        homeToUpdate.Description = homeData.Description ?? homeToUpdate.Description;
        homeToUpdate.Levels = homeData.Levels ?? homeToUpdate.Levels;
        homeToUpdate.ImgUrl = homeData.ImgUrl ?? homeToUpdate.ImgUrl;

        _homesRepository.Update(homeToUpdate);
        return homeToUpdate;
    }
}