using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Api.Models
{
    public class ArtistDetails : ArtistModel
    {
        private IEnumerable<AlbumsModel> albums;

        public ArtistDetails()
        {
            this.albums = new List<AlbumsModel>();            
        }

        public IEnumerable<AlbumsModel> Albums
        {
            get { return albums; }
            set { albums = value; }
        }

        public int Id { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Alias { get; set; }

        public string Country { get; set; }
    }
}