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
    public static class SongsController
    {
        public static List<Song> GetAll(HttpClient client)
        {
            var getSongsResponse = client.GetAsync("Songs").Result;            

            CheckStatus(getSongsResponse);

            var songsJson = getSongsResponse.Content.ReadAsStringAsync().Result;

            var songs = JsonConvert.DeserializeObject<List<Song>>(songsJson);

            return songs;
        }

        public static Song Get(int id, HttpClient client)
        {
            var getSongResponse = client.GetAsync("Songs/" + id).Result;
            CheckStatus(getSongResponse);

            var songJson = getSongResponse.Content.ReadAsStringAsync().Result;

            var song = JsonConvert.DeserializeObject<Song>(songJson);

            return song;
        }

        public static void Add(Song song, HttpClient client)
        {
            var serializedContent = JsonConvert.SerializeObject(song);

            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var postArtist = client.PostAsync("Songs", content).Result;

            if (postArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(postArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(postArtist.ReasonPhrase);
            }
        }

        public static void Update(Song song, HttpClient client)
        {
            var serializedContent = JsonConvert.SerializeObject(song);

            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var putArtist = client.PutAsync("Songs/" + song.Id, content).Result;

            if (putArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(putArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(putArtist.ReasonPhrase);
            }
        }

        public static void Delete(Song song, HttpClient client)
        {
            var postArtist = client.DeleteAsync("Songs/" + song.Id).Result;

            if (postArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(postArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(postArtist.ReasonPhrase);
            }
        }

        private static void CheckStatus(HttpResponseMessage getArtistsResponse)
        {
            if (!getArtistsResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("There was an error in Http Response : {0}", getArtistsResponse.StatusCode));
            }
        }
    }
}
