using Album.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private IAlbumService<Models.Album> iAlbumService;

        public AlbumController(IAlbumService<Models.Album> iAlbumService)
        {
            this.iAlbumService = iAlbumService;
        }

        // GET: api/Album
        [HttpGet]
        public IActionResult Get()
        {
            var results = iAlbumService.GetAlbums();
            return Ok(results);
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(iAlbumService.GetAlbum(id));
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Album album)
        {
            iAlbumService.PutAlbum(id, album);
        }

        // POST: api/Album
        [HttpPost]
        public IActionResult Post([FromBody] Models.Album album)
        {
            iAlbumService.PostAlbum(album);
            return CreatedAtAction("GetAlbummodel", new { id = album.Id }, album);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            iAlbumService.DeleteAlbum(id);
            return NoContent();
        }
    }
}
