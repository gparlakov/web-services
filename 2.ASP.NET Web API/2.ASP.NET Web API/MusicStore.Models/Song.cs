using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        [Required]
        public virtual Artist Artist { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new List<Album>();
        }   
        
        public virtual ICollection<Album> Albums
        {
            get { return albums; }
            set { albums = value; }
        }
    }
}
