using System.Collections.Generic;

namespace Album.Api.Services
{
    public interface IAlbumService<T>
    {
        public T PostAlbum(T album);

        public void PutAlbum(int id, T album);

        public IEnumerable<T> GetAlbums();

        public T GetAlbum(int id);

        public void DeleteAlbum(int id);
    }
}