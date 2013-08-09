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
               
    }
}
