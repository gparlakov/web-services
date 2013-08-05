using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.SQLServerContext
{
    public static class DataObjectsManager
    {
        public static Artist GetOrCreateArtist(Artist artist, MusicStoreDb musicStoreDbContext)
        {
            Artist existingArtist = null;
            if (artist.Id != 0)
            {
                existingArtist = musicStoreDbContext.Artists.FirstOrDefault(a => a.Id == artist.Id); 
            }
            else if (artist.Name != null)
            {
                existingArtist = musicStoreDbContext.Artists.FirstOrDefault(a => a.Name == artist.Name); 
            }

            if (existingArtist != null)
            {
                return existingArtist;
            }

            musicStoreDbContext.Artists.Add(artist);
            musicStoreDbContext.SaveChanges();

            return artist;
        }

        public static Album GetOrCreateAlbum(Album album, MusicStoreDb musicStoreDbContext)
        {
            Album existingAlbum = null;

            if (album.Id != 0)
            {
                existingAlbum = musicStoreDbContext.Albums.FirstOrDefault(a => a.Id == album.Id);
            }
            else if (album.Title != null)
            {
                existingAlbum = musicStoreDbContext.Albums.FirstOrDefault(a => a.Title == album.Title);
            }

            if (existingAlbum != null)
            {
                return existingAlbum;
            }

            musicStoreDbContext.Albums.Add(album);
            musicStoreDbContext.SaveChanges();

            return album;
        }
    }
}
