using Api_Disney.Data;
using Api_Disney.Exceptions;
using Api_Disney.Models;
using Api_Disney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Services
{
    public class CharactersServices : ICharactersServices
    {
        private readonly DbDisneyContext _context;

        public CharactersServices(DbDisneyContext context)
        {
            _context = context;
        }


        public async Task<List<Character>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character?> GetCharacter(int id)
        {
             return await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task PutCharacter(int id, Character character)
        {
            var exits = await  CharacterExistsAsync(id);


            if (!exits)
            {
                throw new CharactersNotFoundException(id);
            }



            var duplicateCharacter = await _context.Characters.AnyAsync(c => c.Nombre == character.Nombre && c.Id != id);

            if (duplicateCharacter)
            {
                throw new CharacterAlreadyExistsException(character.Nombre);
            }

            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Character> PostCharacter(Character character)
        {

            // Verificar si ya existe un personaje con el mismo nombre
            var exists = await _context.Characters
                                       .AnyAsync(c => c.Nombre == character.Nombre);

            if (exists)
            {
                throw new CharacterAlreadyExistsException(character.Nombre); // Excepción personalizada
            }

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            
            return character;
        }
        public async Task DeleteCharacter(int id)
        {
            var character = await GetCharacter(id);
            if (character is null)
            {
                throw new CharactersNotFoundException(id);
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }


        private async Task<bool> CharacterExistsAsync(int id)
        {
            return await _context.Characters.AnyAsync(e => e.Id == id);
        }

        public async Task<List<Character>> GetCharactersFilter(string? name, DateTime? age, float? weight, string? movies)
        {
            // Empezamos con una consulta base para personajes
            var query = _context.Characters.AsQueryable();

            // Filtrar por nombre
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Nombre.ToLower().Contains(name.ToLower()));
            }


            // Filtrar por edad
            if (age.HasValue)
            {
                query = query.Where(c => c.FechaCreacion.Date == age.Value.Date);
            }

            // Filtrar por peso
            if (weight.HasValue)
            {
                query = query.Where(c => c.Peso == weight.Value);
            }

            // Filtrar por películas/series
            if (!string.IsNullOrEmpty(movies))
            {
                query = query.Where(c => c.Movies.Any(m => m.Titulo.ToLower().Contains(movies.ToLower())));
            }

            // Ejecutar la consulta y retornar la lista filtrada
            return await query.ToListAsync();
        }
    }
}
