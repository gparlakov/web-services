using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Api.Models
{
    public class ArtistDetails : ArtistModel
    {
        private IEnumerable<AlbumModel> albums;

        public ArtistDetails()
        {
            this.albums = new List<AlbumModel>();            
        }

        public IEnumerable<AlbumModel> Albums
        {
            get { return albums; }
            set { albums = value; }
        }       

        public DateTime? DateOfBirth { get; set; }

        public string Alias { get; set; }
    }
}