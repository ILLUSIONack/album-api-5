using System.Collections.Generic;

namespace Album.Api.Services
{
    public interface IAlbumService
    {
        List<Models.Album> GetAlbums();

        Models.Album GetAlbum(int id);

        void PostAlbum(Models.Album album);

        void PutAlbum(int id, Models.Album album);

        void DeleteAlbum(int id);
    }
}