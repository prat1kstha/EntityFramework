using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidzyCodeFirst.EntityConfigurations;

namespace VidzyCodeFirst
{
    public class VidzyContext : DbContext
    {
        public VidzyContext() : base("name = VidzyContext")
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfig());
            modelBuilder.Configurations.Add(new GenreConfig());
        }
    }
}
