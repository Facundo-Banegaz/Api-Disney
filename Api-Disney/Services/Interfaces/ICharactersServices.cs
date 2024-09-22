using Api_Disney.Models;

namespace Api_Disney.Services.Interfaces
{
    public interface ICharactersServices
    {
        Task<List<Character>> GetCharacters();
        Task<Character?> GetCharacter(Guid id);
        Task PutCharacter(Guid id, Character character);
        Task<Character> PostCharacter(Character character);
        Task DeleteCharacter(Guid id);
        Task<List<Character>> GetCharactersFilter(string? name, DateTime? age, float? weight, string? movies);
    }
}
