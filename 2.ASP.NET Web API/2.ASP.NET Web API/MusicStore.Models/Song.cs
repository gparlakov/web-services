using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        [Required]
        public virtual Artist Artist { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }
    }
}
