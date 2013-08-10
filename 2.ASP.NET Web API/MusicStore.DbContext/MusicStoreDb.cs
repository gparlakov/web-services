using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MusicStore.Models;

namespace MusicStore.SQLServerContext
{
    public class MusicStoreDb : DbContext
    {
        public MusicStoreDb()
            :base("MusicStoreDb")
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Album>()
            //    .HasKey(a => a.Id)
            //    .HasOptional(a => a.Songs)
            //    .WithMany()                
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Album>()
            //   .HasOptional(a => a.Artists)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            modelBuilder.Entity<Song>()
               .HasOptional(a => a.Artist)
               .WithMany()
               .WillCascadeOnDelete(true);
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
