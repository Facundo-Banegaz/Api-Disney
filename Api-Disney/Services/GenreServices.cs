using Api_Disney.Data;
using Api_Disney.DTOs;
using Api_Disney.Exceptions;
using Api_Disney.Models;
using Api_Disney.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Services
{
    public class GenreServices: IGenreServices
    {
        private readonly DbDisneyContext _context;

        public GenreServices(DbDisneyContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetGenre(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task PutGenre(int id, Genre genre)
        {
            var exits =    GenreExists(id);



            if (!exits)
            {
                throw new GenreNotFoundException(id);
            }

             _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task<Genre> PostGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task DeleteGenre(int id)
        {
            var genre = await GetGenre(id);
            if (genre is null)
            {
                throw new GenreNotFoundException(id);
            }

            _context.Genres.Remove(genre);

            await _context.SaveChangesAsync();
        }
        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
