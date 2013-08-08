using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Api.Models
{
    public class SongDetails : SongModel
    {
        private IEnumerable<AlbumModel> albums;

        public SongDetails()
        {
            this.albums = new List<AlbumModel>();
        }        

        public string Genre { get; set; }

        public ArtistModel Artist { get; set; }

        public IEnumerable<AlbumModel> Albums
        {
            get { return albums; }
            set { albums = value; }
        }        
    }
}