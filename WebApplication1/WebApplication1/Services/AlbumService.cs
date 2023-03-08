using Microsoft.Extensions.Options;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AlbumServices : CollectionService<Album>, IService<Album>
    {
        public AlbumServices(IOptions<DBSettings> dbSettings)
            : base(dbSettings, dbSettings.Value.AlbumCollectionName)
        {
        }
    }
}