using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api
{
    public class AlbumContext : DbContext
    {
        public DbSet<Models.Album> Albums { get; set; }

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=cnsd-db-391046032910-1.coi1e4aatzjc.us-east-1.rds.amazonaws.com;Port=5432;Database=albumdatabase;User Id=postgres;Password=Iamthebest123;");
    }
}
