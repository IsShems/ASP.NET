using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ASP.NET_Core_.Model;

namespace ASP.NET_Core_.Pages
{
    public class QuotesPageModel : PageModel
    {
        public static List<Quote> quotes = new List<Quote>();
        public string? SearchString { get; set; }

        public string? ResultAuthor { get; set; }

        public string? ResultQuote { get; set; }

        //[HttpGet]
        public void OnGet() // Dla proverki Thomas Edison 
        {
            //int quote = -1;
            if (!string.IsNullOrEmpty(SearchString))
            {
                FetchQuotesFromApi();
                GetQuoteIndexByAuthor(SearchString);

                //return quote;
            }
            else
            {
                ResultQuote = "No quote found for the specified author.";
                ResultAuthor = "-";
                //return quote;
            }
        }

        public async Task FetchQuotesFromApi()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var apiUrl = "https://type.fit/api/quotes";
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        quotes = JsonConvert.DeserializeObject<List<Quote>>(content);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch quotes from API. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while fetching quotes: {ex.Message}");
                }
            }
        }

        public void GetQuoteIndexByAuthor(string SearchString)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(SearchString))
            {
                for (int i = 0; i < quotes.Count - 1; i++)
                {
                    if (quotes[i].Author.Contains(SearchString))
                    {
                        result = i;
                        break;
                    }
                }
            }
            ResultQuote = quotes[result].Text;
            ResultAuthor = quotes[result].Author;
        }
    }

}
