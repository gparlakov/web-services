using MusicStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ConsoleClient
{
    public static class ArtistsController
    {
        public static List<Artist> GetAll(HttpClient client)
        {
            var getArtistsResponse = client.GetAsync("Artists").Result;

            var artistsJson = getArtistsResponse.Content.ReadAsStringAsync().Result;
            var artists = JsonConvert.DeserializeObject<List<Artist>>(artistsJson);

            return artists;
        }

        public static Artist Get(int id, HttpClient client)
        {
            var getArtistResponse = client.GetAsync("Artists/" + id).Result;

            var artistJson = getArtistResponse.Content.ReadAsStringAsync().Result;
            var artist = JsonConvert.DeserializeObject<Artist>(artistJson);

            return artist;
        }

        public static void Add(Artist artist, HttpClient client)
        {
            var serializedContent = JsonConvert.SerializeObject(artist);

            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var postArtist = client.PostAsync("Artists", content).Result;

            if (postArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(postArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(postArtist.ReasonPhrase);
            }
        }

        public static void Update(Artist artist, HttpClient client)
        {
            var serializedContent = JsonConvert.SerializeObject(artist);

            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var putArtist = client.PutAsync("Artists/" + artist.Id, content).Result;

            if (putArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(putArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(putArtist.ReasonPhrase);
            }
        }

        public static void Delete(Artist artist, HttpClient client)
        {         
            var postArtist = client.DeleteAsync("Artists/" + artist.Id).Result;

            if (postArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(postArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(postArtist.ReasonPhrase);
            }
        }
    }
}
