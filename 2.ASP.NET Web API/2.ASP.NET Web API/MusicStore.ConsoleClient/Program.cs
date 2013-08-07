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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddressUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //ArtistsController.Add(new Artist { Name = "Carray" }, client);
            //ArtistsController.Add(new Artist { Name = "Jackson" }, client);

            // after first run
            // Update-Database -StartUpProjectName MusicStore.Api 
            // to add unique index on Artist name, song and album title

            //var artists = ArtistsController.GetAll(client);
            //var firstArtistId = artists.First().Id;
            //foreach (var artist in artists)
            //{
            //    Console.WriteLine(artist.Id + " " + artist.Name);
            //}

            //var firstArtist = ArtistsController.Get(firstArtistId, client);

            //firstArtist.Country = "USA";
            //firstArtist.DateOfBirth = new DateTime(1982, 1, 30);

            //ArtistsController.Update(firstArtist, client);

            //var song1 = new Song { Title = "First Song1", Artist = firstArtist, Year = 1993 };
            //var song2 = new Song { Title = "Second Song", Artist = firstArtist, Year = 1994 };

            //SongsController.Add(song1, client);
            //SongsController.Add(song2, client);

            var allSongs = SongsController.GetAll(client);
            //var firstSongId = allSongs.First().Id;

            //var firstSong = SongsController.Get(firstSongId, client);

            //SongsController.Delete(firstSong, client);

            //var album = new Album
            //{
            //    Title = "First Album",
            //    Artists = artists,
            //    Songs = allSongs
            //};

            //var setting = new JsonSerializerSettings();
            //setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //var serialized = JsonConvert.SerializeObject(album, setting);

            //var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            //var addAlbum = client.PostAsync("Albums", content).Result;
            //Console.WriteLine(addAlbum.Content.ReadAsStringAsync().Result);

        }
                
    }
}
