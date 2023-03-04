namespace WebApplication1.Models;

public class SongDBSettings
{
    public string ConnectionString { get; set; } = null;
    public string DatabaseName { get; set; } = null;
    public string SongCollectionName { get; set; } = null;
}