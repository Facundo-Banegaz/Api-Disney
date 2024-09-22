using Api_Disney.Models;

namespace Api_Disney.Services.Interfaces
{
    public interface IGenreServices
    {
        Task<List<Genre>> GetGenres();

        Task<Genre?> GetGenre(Guid id);
        Task PutGenre(Guid id, Genre genre);

        Task<Genre> PostGenre(Genre genre);

        Task DeleteGenre(Guid id);
    }
}
