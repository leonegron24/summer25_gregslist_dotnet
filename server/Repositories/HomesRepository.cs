
using gregslist_dotnet.Interfaces;

namespace gregslist_dotnet.Repositories;

public class HomesRepository : IRepository<Home>
{
    private readonly IDbConnection _db;

    public HomesRepository(IDbConnection db)

    {
        _db = db;
    }

    public Home Create(Home data)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Home GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Home updateData)
    {
        throw new NotImplementedException();
    }

    public List<Home> GetAll()
    {
        string sql = @"
        SELECT homes.*, accounts.*
        FROM homes
        JOIN accounts ON homes.creator_id = accounts.id
        ORDER BY homes.created_at ASC;
        ";
        List<Home> homes = _db.Query(sql, (Home home, Account account) =>
            {
                home.Creator = account;
                return home;
            }).ToList();

        return homes;
    }
}