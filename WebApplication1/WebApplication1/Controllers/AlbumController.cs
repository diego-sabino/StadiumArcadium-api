using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : BaseController<Album, AlbumServices>
    {
        public AlbumController(AlbumServices albumService) : base(albumService)
        {
        }
    }
}
