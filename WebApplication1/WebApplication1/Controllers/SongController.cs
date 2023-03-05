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
    public async Task<List<Song>> GetSongs() =>
        await _songServices.GetAsync();

    [HttpPost]
    public async Task<Song> PostSong(Song song)
    {
        await _songServices.CreateAsync(song);
        return song;
    }
    
    [HttpGet("{id:length(24)}")]
    public async Task<Song> GetSong(string id) =>
        await _songServices.GetAsync(id);
    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Song updatedSong) {
        var song = await _songServices.GetAsync(id);

        if (song is null) {
            return NotFound();
        }

        updatedSong.Id = song.Id;

        await _songServices.UpdateAsync(id, updatedSong);

        return NoContent();
    }
    
    [HttpDelete("{id:length(24)}")]
    public async Task DeleteSong(string id) =>
        await _songServices.RemoveAsync(id);
}