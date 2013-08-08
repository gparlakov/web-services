using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicStore.Models;
using MusicStore.SQLServerContext;

namespace MusicStore.Api.Controllers
{
    public class AlbumsController : ApiController
    {
        private MusicStoreDb db = new MusicStoreDb();

        public AlbumsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Albums
        public IQueryable<Album> GetAlbums()
        {            
            return db.Albums.Include("Songs").Include("Artists").AsQueryable();
        }

        // GET api/Albums/5
        public Album GetAlbum(int id)
        {
            Album album = db.Albums.Include("Artists").Include("Songs").FirstOrDefault(al => al.Id == id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }            

            db.Entry(album).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Albums
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                SyncronizeAlbumWithDb(album);                
                
                db.Albums.Add(album);
                db.SaveChanges();

                SyncSongsWithNewAlbum(album);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        // POST api/Albums/AddArtist/5
        [HttpPost]
        public HttpResponseMessage AddArtist(int id, [FromBody]Artist artist)
        {
            var album = db.Albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                var message = string.Format("No album with id = {0} was found", id);

                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    new KeyNotFoundException(message));
            }

            var addedArtist = DataObjectsManager.GetOrCreateArtist(artist, db);

            album.Artists.Add(addedArtist);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void SyncronizeAlbumWithDb(Album album)
        {
            if (album.Artists != null && album.Artists.Count > 0)
            {
                var addedArtists = new List<Artist>();
                foreach (var artist in album.Artists)
                {
                    addedArtists.Add(DataObjectsManager.GetOrCreateArtist(artist, db));
                }

                album.Artists = addedArtists;
            }

            if (album.Songs != null && album.Songs.Count > 0)
            {
                var addedSongs = new List<Song>();
                foreach (var song in album.Songs)
                {
                    addedSongs.Add(DataObjectsManager.GetOrCreateSong(song, db));
                }

                album.Songs = addedSongs;
            }
        }

        private void SyncSongsWithNewAlbum(Album album)
        {
            foreach (var song in album.Songs)
            {
                song.Albums.Add(album);
            }
            db.SaveChanges();
        }            
    }
}