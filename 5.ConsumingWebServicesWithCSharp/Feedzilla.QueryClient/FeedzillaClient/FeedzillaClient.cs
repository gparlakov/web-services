using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Feedzilla.QueryClient
{
    public class FeedzillaClient
    {
        private const string FeedzillaApiUri = "http://api.feedzilla.com/v1/";

        private readonly HttpClient client;

        public FeedzillaClient()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(FeedzillaApiUri);
            this.client.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Category> GetCategories(bool orderedByMostPopular = false)
        {
            var requestUri = "categories";
            if (orderedByMostPopular)
            {
                requestUri += "?order=popular";
            }
            var response = this.client.GetAsync(requestUri).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("Error in http request: {0}", response.ReasonPhrase));
            }

            var responseText = response.Content.ReadAsStringAsync().Result;

            var categories = JsonConvert.DeserializeObject<List<Category>>(responseText);

            return categories;
        }

        public IEnumerable<Article> GetArticles(SearchOptions options)
        {
            var serviceQuery = string.Format("categories/{0}/articles/search.json?q={1}&order={2}&count={3}", 
                options.CategoryId, options.SearchText, options.Order.ToString(), options.ResultsCount);

            if (options.Since != null)
            {
                var sinceQuery = options.Since.Value.ToString("YYYY-MM-DD");
                serviceQuery += "&since=" + sinceQuery;
            }

            var articlesResponse = this.client.GetAsync(serviceQuery).Result;

            if (!articlesResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error in http response: " + articlesResponse.ReasonPhrase);
            }

            var articlesResponseContent = articlesResponse.Content.ReadAsStringAsync().Result;

            // Takes the object Articles:[{article},{article},{}] and and serializes
            // it into a new anonymous object with property Articles of type List<Articles>
            var articles = JsonConvert.DeserializeAnonymousType(
                articlesResponseContent, new { Articles = new List<Article>() });

            return articles.Articles;
        }
    }
}
