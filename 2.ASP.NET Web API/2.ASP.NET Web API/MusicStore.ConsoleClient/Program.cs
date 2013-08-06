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

            // ArtistsController.Add(new Artist { Name = "Carray1" }, client);
            // ArtistsController.Add(new Artist { Name = "Jackson1" }, client);

            // after first run
            // Update-Database -StartUpProjectName MusicStore.Api 
            // to add unique index on Artist name, song and album title

            var artists = Controller<Artist>.GetAll(client, "Artists");
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name + " " + artist.Id);
            }
                                
            var firstArtist = ArtistsController.Get(1, client);

            firstArtist.Country = "USA";
            firstArtist.DateOfBirth = new DateTime(1982, 1, 30);

            ArtistsController.Update(firstArtist, client);
        }
    }
}
