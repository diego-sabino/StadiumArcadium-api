using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/songs")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly AlbumServices _albumServices;

    public SongController(AlbumServices albumServices)
    {
        _albumServices = albumServices; 
    }

    [HttpGet]
    public async Task<List<Album>> GetSongs() =>
        await _albumServices.GetAsync();

    [HttpPost]
    public async Task<Album> PostSong(Album album)
    {
        await _albumServices.CreateAsync(album);
        return album;
    }
    
    [HttpGet("{id:length(24)}")]
    public async Task<Album> GetSong(string id) =>
        await _albumServices.GetAsync(id);
    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Album updatedAlbum) {
        var song = await _albumServices.GetAsync(id);

        if (song is null) {
            return NotFound();
        }

        updatedAlbum.Id = song.Id;

        await _albumServices.UpdateAsync(id, updatedAlbum);

        return NoContent();
    }
    
    [HttpDelete("{id:length(24)}")]
    public async Task DeleteSong(string id) =>
        await _albumServices.RemoveAsync(id);
}