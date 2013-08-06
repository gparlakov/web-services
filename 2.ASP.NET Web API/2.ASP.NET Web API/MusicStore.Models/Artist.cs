using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.albums = new List<Album>();
        }

        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Alias { get; set; }
        
        public virtual ICollection<Album> Albums
        {
            get { return albums; }
            set { albums = value; }
        }
    }
}
