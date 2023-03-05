using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/songs")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly SongServices _songServices;

    public SongController(SongServices songServices)
    {
        _songServices = songServices; 
    }

    [HttpGet]
    public async Task<List<Song>> GetSongs()
            => await _songServices.GetAsync();

    [HttpPost]
    public async Task<Song> PostSong(Song song)
    {
        await _songServices.CreateAsync(song);
        return song;
    }
}