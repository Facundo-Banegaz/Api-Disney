using Api_Disney.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;

namespace Api_Disney.Services.Interfaces
{
    public interface IMoviesServices
    {
        Task<List<Movie>> GetMovieOrSeries();
        Task<Movie?> GetMovie(Guid id);
        Task PutMovie(Guid id, Movie movie);

        Task<Movie> PostMovie(Movie movie);
        Task DeleteMovie(Guid id);
        Task<List<Movie>> GetMoviesFilter(string? name, string? genre, string? order);
    }
}
