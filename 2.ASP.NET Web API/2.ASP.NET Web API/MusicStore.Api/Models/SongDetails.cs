using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Api.Models
{
    public class SongDetails : SongModel
    {
        private IEnumerable<AlbumsModel> albums;

        public SongDetails()
        {
            this.albums = new List<AlbumsModel>();
        }

        public int Id { get; set; }

        public string Genre { get; set; }

        public ArtistModel Artist { get; set; }

        public IEnumerable<AlbumsModel> Albums
        {
            get { return albums; }
            set { albums = value; }
        }        
    }
}