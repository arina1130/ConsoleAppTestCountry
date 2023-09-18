using System.Text.Json;
using System;
using WebApplication1.Models;

namespace WebApplication1
{
    public class CountryService
    {
        HttpClient httpClient = new HttpClient();
        public List<Country>? Countries = new List<Country>();
        public CountryService()
        {
            GetJson().Wait();
        }

        async Task GetJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            using Stream stream = await httpClient.GetStreamAsync("https://restcountries.com/v3.1/all");
            Countries = await JsonSerializer.DeserializeAsync<List<Country>>(stream, options);
        }
    }
}
