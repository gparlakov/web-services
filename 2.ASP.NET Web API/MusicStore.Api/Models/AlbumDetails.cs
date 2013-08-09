using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Api.Models
{
    public class AlbumDetails : AlbumModel
    {
        public IEnumerable<ArtistModel> Artists { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}