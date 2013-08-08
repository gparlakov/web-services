using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Album
    {
        private ICollection<Song> songs;

        private ICollection<Artist> artists;

        public Album()
        {
            this.artists = new List<Artist>();
            this.songs = new List<Song>();
        }
        
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }
                
        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }
    }
}
