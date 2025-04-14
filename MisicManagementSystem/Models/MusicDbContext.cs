using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisicManagementSystem.Models
{
    internal class MusicDbContext
    {
        public MusicDbContext() : base("name=MusicDbConnection")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Налаштування первинних ключів
            modelBuilder.Entity<Artist>()
                .HasKey(a => a.artist_id);

            modelBuilder.Entity<Song>()
                .HasKey(s => s.song_id);

            // Налаштування відношення один-до-багатьох
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithRequired(s => s.Artist)
                .HasForeignKey(s => s.artist_id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
