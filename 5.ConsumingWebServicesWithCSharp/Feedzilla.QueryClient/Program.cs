using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Feedzilla.QueryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var feedZillaClient = new FeedzillaClient();

                PrintAllCategories(feedZillaClient, true);

                var searchOptions = TakeSearchOptionsFromUser();               

                PrintArticles(searchOptions, feedZillaClient);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static SearchOptions TakeSearchOptionsFromUser()
        {
            var categoryId = GetInt("In which category should I search? Id = ");

            Console.WriteLine("What to search for - text = ");
            var searchText = Console.ReadLine();

            var results = GetInt("How many results");

            var searchOptions = new SearchOptions(categoryId, searchText, results);

            //var searchOptions = new SearchOptions(5, "Bruno Mars", 5);
            return searchOptions;
        }

        private static int GetInt(string message)
        {
            int parsedInt = 0;
            bool parsed = false;
            do
            {
                Console.WriteLine(message);
                parsed = int.TryParse(Console.ReadLine(), out parsedInt);
            }
            while (parsed == false);
            return parsedInt;
        }

        private static void PrintArticles(SearchOptions searchOptions, FeedzillaClient feedZillaClient)
        {
            var articles = feedZillaClient.GetArticles(searchOptions);

            if (articles.Count() == 0)
            {
                Console.WriteLine("No articles found");
                return;
            }
            var allArticles = new StringBuilder();
            foreach (var article in articles)
            {
                allArticles.Append(article);
            }

            Console.WriteLine(allArticles);
        }

        private static void PrintAllCategories(FeedzillaClient feedZillaClient, bool orderedByPopolarity)
        {
            var categories = feedZillaClient.GetCategories(orderedByPopolarity);

            StringBuilder categoriesAll = new StringBuilder();
            categoriesAll.AppendFormat("{0,5} | {1,35} | {2,35}\n",
                "ID", "Name", "Service Url");
            categoriesAll.AppendLine(new string('-',82));
            foreach (var article in categories)
            {
                categoriesAll.AppendFormat("{0,5} | {1,35} | {2,35}\n",
                    article.Id, article.Name, article.CategoryUrl ?? "None");
            }

            Console.WriteLine(categoriesAll.ToString());
        }
    }
}