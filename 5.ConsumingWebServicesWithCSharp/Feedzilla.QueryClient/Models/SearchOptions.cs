using System;
using System.Linq;

namespace Feedzilla.QueryClient
{
    /// <summary>
    /// The options for articles search
    /// </summary>
    public class SearchOptions
    {
        /// <summary>
        /// Constructor for new articles search options object.
        /// </summary>
        /// <param name="categoryId">Required - the category Id to search into</param>
        /// <param name="searchText">Required - the text to search for in an article</param>
        ///  <param name="resultsCount">Optional - resultsCount of articles to show - dafult is 20 - set by service provider</param>
        public SearchOptions(int categoryId, string searchText, int resultsCount = 20)
        {
            this.SearchText = searchText;
            this.CategoryId = categoryId;
            this.ResultsCount = resultsCount;
        }

        /// <summary>
        /// Required
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Requred
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Optional - date in format "YYYY-MM-DD"
        /// </summary>
        public DateTime? Since { get; set; }

        /// <summary>
        /// Values "relevance", "date" - daulft is relevance 
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Optional - default value is 20 - set by service provider
        /// </summary>
        public int ResultsCount { get; set; }
    }
}