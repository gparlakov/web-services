using System;
using System.Linq;
using Newtonsoft.Json;

namespace Feedzilla.QueryClient
{
    public class Article
    {
        [JsonProperty("publish_date")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("url")]
        public string ArticleUrl { get; set; }

        public override string ToString()
        {
            var date = this.PublishDate.ToString("yyyy-MM-dd");
            var endArticle = new string('>', 80);
            var result = string.Format("\nAuthor:{0,-30} {1,30}\n{2,75}\n{3}\nURL:{4}\n{5}",
                this.Author?? "(Anonymous)", "Published: " + date, this.Title, this.Summary, this.ArticleUrl, endArticle);

            return result;
        }
    }
}
