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
using MusicStore.Api.Models;

namespace MusicStore.Api.Controllers
{
    public class SongsController : ApiController
    {
        private MusicStoreDb db = new MusicStoreDb();

        public SongsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Songs
        public IQueryable<SongDetails> GetSongs()
        {
            var songs = db.Songs.Select(s => new SongDetails
            {
                Title = s.Title,
                Year = s.Year,
                Genre = s.Genre,
                Artist = new ArtistModel { Name = s.Artist.Name },
                Albums = s.Albums.Select(al => new AlbumsModel
                {
                    Title = al.Title
                }).ToList(),
            });

            return songs;
        }

        // GET api/Songs/5
        public SongDetails GetSong(int id)
        {
            Song song = db.Songs.Include("Artist").FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var songDetails =  new SongDetails
            {
                Title = song.Title,
                Year = song.Year,
                Genre = song.Genre,
                Artist = new ArtistModel { Name = song.Artist.Name },
                Albums = song.Albums.Select(al => new AlbumsModel
                {
                    Title = al.Title
                }).ToList(),
            };

            return songDetails;
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            db.Entry(song).State = EntityState.Modified;

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

        // POST api/Songs
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                Artist songArtist = null;

                if (song.Artist != null)
                {
                    songArtist = DataObjectsManager.GetOrCreateArtist(song.Artist, db);
                }

                song.Artist = songArtist;

                db.Songs.Add(song);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = db.Songs.FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}