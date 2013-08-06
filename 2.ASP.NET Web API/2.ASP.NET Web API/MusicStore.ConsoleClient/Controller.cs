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
    public static class Controller<T> where T:IEntity
    {
        public static List<T> GetAll(HttpClient client, string servicePath)
        {
            var response = client.GetAsync(servicePath).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var entityList = JsonConvert.DeserializeObject<List<T>>(json);

            return entityList;
        }

        public static T Get(int id, HttpClient client, string servicePath)
        {
            var response = client.GetAsync(servicePath + "/" + id).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var entity = JsonConvert.DeserializeObject<T>(json);

            return entity;
        }

        public static void Add(T entity, HttpClient client, string servicePath)
        {
            var serializedContent = JsonConvert.SerializeObject(entity);

            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var postRequest = client.PostAsync(servicePath, content).Result;

            if (postRequest.IsSuccessStatusCode)
            {
                Console.WriteLine(postRequest.Headers.Location);
            }
            else
            {
                Console.WriteLine(postRequest.ReasonPhrase);
            }
        }

        public static void Update(T entity, HttpClient client, string servicePath)
        {
            var serializedContent = JsonConvert.SerializeObject(entity);

            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var putArtist = client.PutAsync(servicePath + "/" + entity.Id, content).Result;

            if (putArtist.IsSuccessStatusCode)
            {
                Console.WriteLine(putArtist.Headers.Location);
            }
            else
            {
                Console.WriteLine(putArtist.ReasonPhrase);
            }
        }

        public static void Delete(T artist, HttpClient client)
        {
            var postArtist = client.DeleteAsync("Songs/" + artist.Id).Result;

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
