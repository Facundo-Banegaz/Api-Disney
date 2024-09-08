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
             return await _context.Characters.FindAsync(id);
        }


        public async Task PutCharacter(int id, Character character)
        {
            var exits = CharacterExists(id);


            if (!exits)
            {
                throw new CharactersNotFoundException(id);
            }

            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Character> PostCharacter(Character character)
        {
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


        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
