using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Services
{
    public class AlbumService : IAlbumService<Models.Album>
    {
        private readonly AlbumContext albumContext;

        public AlbumService(AlbumContext albumContext)
        {
            this.albumContext = albumContext;
        }

        public Models.Album PostAlbum(Models.Album album)
        {
            albumContext.Albums.Add(album);
            albumContext.SaveChanges();
            return album;
        }

        public void DeleteAlbum(int id)
        {
            var result = albumContext.Albums.Where(a => a.Id == id).FirstOrDefault();
            albumContext.Albums.Remove(result);
            albumContext.SaveChanges();
        }

        public IEnumerable<Models.Album> GetAlbums()
        {
            var result = albumContext.Albums.ToList();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Models.Album GetAlbum(int id)
        {
            var result = albumContext.Albums.Where(a => a.Id == id).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public void PutAlbum(int id, Models.Album album)
        {
            var result = albumContext.Albums.Where(a => a.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Name = album.Name;
                result.Artist = album.Artist;
                result.ImageUrl = album.ImageUrl;
                albumContext.SaveChanges();
            }
        }
    }
}
