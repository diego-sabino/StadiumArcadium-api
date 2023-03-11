using Microsoft.Extensions.Options;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SongServices : BaseServices<Song>, IService<Song>
    {
        public SongServices(IOptions<DBSettings> dbSettings)
            : base(dbSettings, dbSettings.Value.SongCollectionName)
        {
        }
    }
}