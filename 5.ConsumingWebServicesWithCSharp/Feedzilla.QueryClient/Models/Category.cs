using System;
using System.Linq;
using Newtonsoft.Json;

namespace Feedzilla.QueryClient
{
    public class Category
    {
        [JsonProperty("category_id")]
        public int Id { get; set; }

        [JsonProperty("english_category_name")]
        public string Name { get; set; }

        [JsonProperty("url_category_name")]
        public string CategoryUrl { get; set; }
    }
}
