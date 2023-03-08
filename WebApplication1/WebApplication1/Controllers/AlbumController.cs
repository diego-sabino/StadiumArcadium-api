using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/albums")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly AlbumsServices _albumServices;

    public AlbumController(AlbumsServices albumServices)
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
        var album = await _albumServices.GetAsync(id);

        if (album is null) {
            return NotFound();
        }

        updatedAlbum.Id = album.Id;

        await _albumServices.UpdateAsync(id, updatedAlbum);

        return NoContent();
    }
    
    [HttpDelete("{id:length(24)}")]
    public async Task DeleteSong(string id) =>
        await _albumServices.RemoveAsync(id);
}