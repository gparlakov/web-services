using MusicStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ConsoleClient
{
    class Program
    {
        const string BaseAddressUri = "http://localhost:49308/api/";

        static void Main()
        {
            #region Initializing 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddressUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var rand = new Random(); 
            #endregion

            AddTwoArtists(client, rand);

            #region To add Unique Constraints to data base
            // after first run
            // Update-Database -StartUpProjectName MusicStore.Api 
            // to add unique index on Artist name, song and album title 
            #endregion

            List<Artist> artists = ArtistsController.GetAll(client);
            int randArtistId = artists[rand.Next(artists.Count)].Id;
            PrintAllArtists(artists);

            var randArtist = ArtistsController.Get(randArtistId, client);

            //UpdateFirstArtist(client, firstArtist);

            AddTwoSongs(client, rand, randArtist);

            var allSongs = PrintAllSongs(client);

            //DeleteFirstSong(client, allSongs);

            AddAlbum(client, rand, artists, allSongs);
            //Console.WriteLine(addAlbum.Content.ReadAsStringAsync().Result);
        }

        private static List<Song> PrintAllSongs(HttpClient client)
        {
            var allSongs = SongsController.GetAll(client);
            foreach (var song in allSongs)
            {
                Console.WriteLine("Song: title: {0} year: {1} by: {2} in albums {3}", song.Title, song.Year, song.Artist.Name, song.Albums.Count);
            }
            return allSongs;
        }

        private static void AddAlbum(HttpClient client, Random rand, List<Artist> artists, List<Song> allSongs)
        {
            var album = new Album
            {
                Title = "Album" + GetRandomSuffix(rand),
                Artists = artists,
                Songs = allSongs
            };

            var setting = new JsonSerializerSettings();
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            var serialized = JsonConvert.SerializeObject(album, setting);

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var addAlbum = client.PostAsync("Albums", content).Result;
        }

        private static void DeleteFirstSong(HttpClient client, List<Song> allSongs)
        {
            var firstSongId = allSongs.First().Id;

            var firstSong = SongsController.Get(firstSongId, client);

            SongsController.Delete(firstSong, client);
        }

        private static void AddTwoSongs(HttpClient client, Random rand, Artist firstArtist)
        {
            var song1 = new Song { Title = "Song" + GetRandomSuffix(rand), Artist = firstArtist, Year = 1993 };
            var song2 = new Song { Title = "Song" + GetRandomSuffix(rand), Artist = firstArtist, Year = 1994 };

            SongsController.Add(song1, client);
            SongsController.Add(song2, client);
        }

        private static void UpdateFirstArtist(HttpClient client, Artist firstArtist)
        {
            firstArtist.Country = "USA";
            firstArtist.DateOfBirth = new DateTime(1982, 1, 30);

            ArtistsController.Update(firstArtist, client);
        }

        private static void PrintAllArtists(List<Artist> artists)
        {  
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Id + " " + artist.Name);
            }
        }

        private static void AddTwoArtists(HttpClient client, Random rand)
        {

            ArtistsController.Add(new Artist { Name = "Artist" + GetRandomSuffix(rand) }, client);
            ArtistsController.Add(new Artist { Name = "Artist" + GetRandomSuffix(rand) }, client);
        }

        private static string GetRandomSuffix(Random rand)        
        {
            var lenght = rand.Next(10);

            var randomName = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                randomName.Append((char)(rand.Next('a'-1, 'z')));
            }

            return randomName.ToString();
        }
                
    }
}
