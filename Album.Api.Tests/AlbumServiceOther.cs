using Album.Api.Models;
using Album.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Api.Tests
{
    public class AlbumServiceOther : IAlbumService<Models.Album>
    {

        private readonly List<Models.Album> _albummodels;
        public AlbumServiceOther()
        {
            _albummodels = new List<Models.Album>()
            {
                new Models.Album() { Id = 1,
                    Name = "Orange Juice", Artist="Orange Tree", ImageUrl = "https://www.google.com" },
                new Models.Album() { Id = 2,
                    Name = "Diary Milk", Artist="Cow", ImageUrl = "https://www.google.com" },
                new Models.Album() { Id = 3,
                    Name = "Frozen Pizza", Artist="Uncle Mickey", ImageUrl = "https://www.google.com" }
            };
        }

        public Models.Album PostAlbum(Models.Album _object)
        {
            _object.Id = 4; _object.Name = "Farooq";
            _albummodels.Add(_object);
            return _object;
        }

        public void DeleteAlbum(int Id)
        {
            var existing = _albummodels.First(a => a.Id == Id);
            _albummodels.Remove(existing);
        }

        public IEnumerable<Models.Album> GetAlbums()
        {
            return _albummodels;
        }

        public Models.Album GetAlbum(int Id)
        {
            return _albummodels.Where(a => a.Id == Id)
                .FirstOrDefault();
        }

        public void PutAlbum(int Id, Models.Album _object)
        {
            throw new NotImplementedException();
        }
    }
}
