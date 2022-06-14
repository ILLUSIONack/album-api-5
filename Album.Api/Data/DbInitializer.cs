using System;
using System.Linq;

namespace Album.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AlbumContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Albums.Any())
            {
                return;   // DB has been seeded
            }

            var albums = new Album.Api.Models.Album[]
            {
            new Album.Api.Models.Album{Name="Carson",Artist="Alexander",ImageUrl="usman"},
            new Album.Api.Models.Album{Name="Meredith",Artist="Alonso",ImageUrl="hello"}
            };
            foreach (Album.Api.Models.Album s in albums)
            {
                context.Albums.Add(s);
            }
            context.SaveChanges();
        }
    }
}