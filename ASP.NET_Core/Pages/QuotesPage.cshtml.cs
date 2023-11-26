using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ASP.NET_Core_.Model;
using System.Text;

namespace ASP.NET_Core_.Pages
{
    public class QuotesPageModel : PageModel
    {
        public string? ResultAuthor { get; set; }

        public string? ResultQuote { get; set; }

        [HttpPost]
        public async Task OnPost() // Dla proverki: Kevin
        {
            string searchString = Request.Form["searchString"];

            if (!string.IsNullOrEmpty(searchString))
            {

                await FetchQuotesFromApi(searchString);

            }
        }


        public async Task FetchQuotesFromApi(string searchString)
        {
            using (var httpClient = new HttpClient())
            {
                StringBuilder? result;
                HttpClient client = new();

                HttpResponseMessage message = await client.GetAsync("https://dummyjson.com/quotes");

                if (message.IsSuccessStatusCode)
                {
                    result = new(await message.Content.ReadAsStringAsync());

                        var json = result.ToString();
                        if (result != null)
                        {
                            var res = JsonConvert.DeserializeObject<Result>(json);
                            int resultind = -1;

                            if (!string.IsNullOrEmpty(searchString))
                            {
                                for (int i = 0; i < res.quotes.Count - 1; i++)
                                {
                                    if (res.quotes[i].author.Contains(searchString))
                                    {
                                        resultind = i;
                                        break;
                                    }
                                }
                            }
                        if (resultind != -1)
                        {
                            ResultQuote = res.quotes[resultind].quote.ToString();
                            ResultAuthor = res.quotes[resultind].author.ToString();
                        }
                        else
                        {
                            ResultQuote = "No quote found for the specified author.";
                            ResultAuthor = "-";
                        }
                    }
                }
     
            }
        }
    }

}
