using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
public class SongController : BaseController<Song, SongServices>
{
    public SongController(SongServices songServices) : base(songServices)
    {
    }
}