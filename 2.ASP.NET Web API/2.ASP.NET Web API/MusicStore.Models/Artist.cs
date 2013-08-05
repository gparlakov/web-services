using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Alias { get; set; }
    }
}
