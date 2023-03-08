using Microsoft.Extensions.Options;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SongServices : CollectionService<Song>
    {
        public SongServices(IOptions<DBSettings> dbSettings)
            : base(dbSettings, dbSettings.Value.SongCollectionName)
        {
        }
    }
}