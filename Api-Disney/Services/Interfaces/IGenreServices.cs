using Api_Disney.Models;

namespace Api_Disney.Services.Interfaces
{
    public interface IGenreServices
    {
        Task<List<Genre>> GetGenres();

        Task<Genre?> GetGenre(int id);
        Task PutGenre(int id, Genre genre);

        Task<Genre> PostGenre(Genre genre);

        Task DeleteGenre(int id);
    }
}
