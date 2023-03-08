namespace WebApplication1.Models;

public class DBSettings
{
    public string ConnectionString { get; set; } = null;
    
    public string DatabaseName { get; set; } = null;
    
    public string SongCollectionName { get; set; } = null;
    
    public string AlbumCollectionName { get; set; } = null;
}