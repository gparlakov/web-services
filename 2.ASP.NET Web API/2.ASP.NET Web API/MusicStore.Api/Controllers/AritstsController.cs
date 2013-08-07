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
    public class ArtistsController : ApiController
    {
        private MusicStoreDb db = new MusicStoreDb();

        public ArtistsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Aritsts
        [HttpGet]
        public IEnumerable<ArtistDetails> GetArtists()
        {
            var artists = db.Artists.Select(a => new ArtistDetails 
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                Alias = a.Alias,
                Country = a.Country,
                Albums = a.Albums.Select(al => new AlbumsModel
                {
                    Title = al.Title
                }),
            }).AsEnumerable();

            return artists;
        }

        // GET api/Aritsts/5
        [HttpGet]
        public ArtistDetails GetArtist(int id)
        {
            Artist artist = db.Artists.Include("Albums").FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var artistDetails = new ArtistDetails
            {
                Id = artist.Id,
                Name = artist.Name,
                DateOfBirth = artist.DateOfBirth,
                Alias = artist.Alias,
                Country = artist.Country,
                Albums = artist.Albums.Select(al => new AlbumsModel
                {
                    Title = al.Title
                }).ToList()
            };

            return artistDetails;
        }

        // PUT api/Aritsts/5
        
        public HttpResponseMessage PutArtist(int id, [FromBody]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != artist.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(artist).State = EntityState.Modified;

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

        // POST api/Aritsts
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Aritsts/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}