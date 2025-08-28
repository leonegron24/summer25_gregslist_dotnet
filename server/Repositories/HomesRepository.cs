
using gregslist_dotnet.Interfaces;

namespace gregslist_dotnet.Repositories;

public class HomesRepository : IRepository<Home>
{
    private readonly IDbConnection _db;

    public HomesRepository(IDbConnection db)

    {
        _db = db;
    }

    public Home Create(Home homeData)
    {
        string sql = @"
        INSERT INTO
        homes (
            bedrooms,
            bathrooms,
            levels,
            price,
            img_url,
            description,
            year,
            creator_id
        )
        VALUES (
            @Bedrooms,
            @Bathrooms,
            @Levels,
            @Price,
            @ImgUrl,
            @Description,
            @Year,
            @CreatorId
        );

        SELECT homes.*, accounts.* 
        FROM homes 
        INNER JOIN accounts ON homes.creator_id = accounts.id
        WHERE homes.id = LAST_INSERT_ID();
        ";

        Home newHome = _db.Query(sql, (Home home, Account account) =>
        {
            home.Creator = account;
            return home;
        }, homeData).SingleOrDefault();

        return newHome;
    }

    public void Delete(int homeId)
    {
        string sql = @"
        DELETE FROM homes 
        WHERE id = @HomeId LIMIT 1;
        ";

        int rowsAffected = _db.Execute(sql, new { HomeId = homeId });

        if (rowsAffected != 1)
        {
            throw new Exception(rowsAffected + "rows have been affected and that is not good");
        }

    }

    public Home GetById(int homeId)
    {
        string sql = @"
        SELECT homes.*, accounts.*
        FROM homes
        INNER JOIN accounts ON homes.creator_id = accounts.id
        WHERE homes.id = @HomeId
        ORDER BY homes.created_at ASC;
        ";

        Home foundHome = _db.Query(sql, (Home home, Account account) =>
        {
            home.Creator = account;
            return home;
        }, new { HomeId = homeId }).SingleOrDefault();
        return foundHome;
    }

    public void Update(Home homeToUpdate)
    {
        string sql = @"
        UPDATE homes 
        SET 
            bedrooms = @Bedrooms,
            bathrooms = @Bathrooms,
            description = @Description,
            levels = @Levels,
            img_url = @ImgUrl
        WHERE 
            id = @Id 
            LIMIT 1;
        ";

        int rowsAffected = _db.Execute(sql, homeToUpdate);

        if (rowsAffected != 1)
        {
            throw new Exception(rowsAffected + "rows have been affected and that is not good");
        }
    }

    public List<Home> GetAll()
    {
        string sql = @"
        SELECT homes.*, accounts.*
        FROM homes
        INNER JOIN accounts ON homes.creator_id = accounts.id
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