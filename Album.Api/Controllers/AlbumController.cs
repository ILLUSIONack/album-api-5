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
        private IAlbumService iAlbumService;

        public AlbumController(AlbumContext albumContext)
        {
            this.iAlbumService = new AlbumService(albumContext);
        }

        [HttpGet]
        public IEnumerable<Models.Album> Get()
        {
            return iAlbumService.GetAlbums();
        }

        [HttpGet("{id}")]
        public Models.Album Get(int id)
        {
            return iAlbumService.GetAlbum(id);
        }

        [HttpPost]
        public void Post([FromBody] Models.Album album)
        {
            iAlbumService.PostAlbum(album);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Album album)
        {
            iAlbumService.PutAlbum(id, album);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            iAlbumService.DeleteAlbum(id);
        }
    }
}
