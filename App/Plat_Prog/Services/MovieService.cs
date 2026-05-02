using Plat_prog.Models;
using System.Text.Json;

namespace Plat_prog.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKey = "d9968a4e";

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> SearchMovies(string title)
        {
            var url = $"http://www.omdbapi.com/?s={title}&apikey={apiKey}";
            var response = await _httpClient.GetStringAsync(url);

            var json = JsonDocument.Parse(response);
            var movies = new List<Movie>();

            if (json.RootElement.TryGetProperty("Search", out var results))
            {
                foreach (var item in results.EnumerateArray())
                {
                    movies.Add(new Movie
                    {
                        Title = item.GetProperty("Title").GetString(),
                        Year = item.GetProperty("Year").GetString(),
                        ImdbId = item.GetProperty("imdbID").GetString(),
                        Poster = item.GetProperty("Poster").GetString()
                    });
                }
            }

            return movies;
        }
        public async Task<Movie> GetMovieDetails(string imdbId)
        {
            var url = $"http://www.omdbapi.com/?i={imdbId}&plot=full&apikey={apiKey}";
            var response = await _httpClient.GetStringAsync(url);

            var json = JsonDocument.Parse(response);

            return new Movie
            {
                Title = json.RootElement.GetProperty("Title").GetString(),
                Year = json.RootElement.GetProperty("Year").GetString(),
                ImdbId = imdbId,
                Poster = json.RootElement.GetProperty("Poster").GetString(),
                Plot = json.RootElement.GetProperty("Plot").GetString(),
                Genre = json.RootElement.GetProperty("Genre").GetString(),
                Director = json.RootElement.GetProperty("Director").GetString(),
                Actors = json.RootElement.GetProperty("Actors").GetString(),
                ImdbRating = json.RootElement.GetProperty("imdbRating").GetString()
            };
        }
    }
}
