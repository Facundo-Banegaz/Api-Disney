using Api_Disney.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Disney.Services.Interfaces
{
    public interface IMoviesServices
    {
        Task<List<Movie>> GetMovieOrSeries();
        Task<Movie?> GetMovie(int id);
        Task PutMovie(int id, Movie movie);

        Task<Movie> PostMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
