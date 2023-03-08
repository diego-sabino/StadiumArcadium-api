using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[Route("api/albums")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly AlbumServices _albumServices;

    public AlbumController(AlbumServices albumServices)
    {
        _albumServices = albumServices; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        var albums = await _albumServices.GetAsync();
        return Ok(albums);
    }

    [HttpPost]
    public async Task<Album> PostAlbum(Album album)
    {
        await _albumServices.CreateAsync(album);
        return album;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Album>> GetAlbum(string id)
    {
        var album = await _albumServices.GetAsync(id);

        if (album is null)
        {
            return NotFound(new { message = "Album not found" });
        }
        
        return Ok(album);
    }
    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Album updatedAlbum) {
        var album = await _albumServices.GetAsync(id);

        if (album is null) {
            return NotFound(new { message = "Album not found" });
        }

        updatedAlbum.Id = album.Id;

        await _albumServices.UpdateAsync(id, updatedAlbum);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteAlbum(string id)
    {
        var album = await _albumServices.GetAsync(id);

        if (album is null) {
            return NotFound(new { message = "Album not found" });
        }
        
        await _albumServices.RemoveAsync(id);
        return NoContent();
    }
}