namespace gregslist_dotnet.Models;

public class Home
{
    public int Id { get; set; }
    public DateTime CreatorId { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Range(0, 30)] public int? Bedrooms { get; set; }
    [Range(0, 25)] public int? Bathrooms { get; set; }
    [Range(1, 4)] public int? Levels { get; set; }
    [Range(0, 10000000)] public int? Price { get; set; }
    [MaxLenth(500)] public string ImgUrl { get; set; }
    [MaxLenth(500)] public string Description { get; set; }
    [Range(1000, 2025)] public int? Year { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}