using PentiMovie.Models;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace PentiMovie.Services
{
    public static class MovieApi
    {
        private const string HOST = "movie-database-imdb-alternative.p.rapidapi.com";
        private const string KEY = "API_KEY";

        public static async Task<SearchResults> SearchAsync(string query)
        {
            var request = CreateRequest(Method.GET);
            request.AddQueryParameter("s", query);

            IRestResponse response = await App.Client.ExecuteAsync(request);

            return JsonSerializer.Deserialize<SearchResults>(response.Content);
        }

        public static async Task<Movie> SearchByIdAsync(string imdbID)
        {
            var request = CreateRequest(Method.GET);
            request.AddQueryParameter("i", imdbID);

            IRestResponse response = await App.Client.ExecuteAsync(request);

            return JsonSerializer.Deserialize<Movie>(response.Content);
        }

        private static RestRequest CreateRequest(Method method)
        {
            var request = new RestRequest(method);

            request.AddHeader("x-rapidapi-host", HOST);
            request.AddHeader("x-rapidapi-key", KEY);

            return request;
        }
    }
}
