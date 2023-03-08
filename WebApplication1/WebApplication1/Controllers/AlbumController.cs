using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : BaseController<Album, AlbumServices>
    {
        public AlbumsController(AlbumServices albumService) : base(albumService)
        {
        }
    }
}