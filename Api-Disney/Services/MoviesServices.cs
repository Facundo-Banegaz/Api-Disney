using Api_Disney.Data;
using Api_Disney.Exceptions;
using Api_Disney.Models;
using Api_Disney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Services
{
    public class MoviesServices: IMoviesServices
    {

        private readonly DbDisneyContext _context;

        public MoviesServices(DbDisneyContext context)
        {
            _context = context;
        }
        public async Task<List<Movie>> GetMovieOrSeries()
        {
            return await _context.MovieOrSeries.Include(g => g.Genero).ToListAsync();
        }
        public async Task<Movie?> GetMovie(int id)
        {
            return await _context.MovieOrSeries.FindAsync(id);

  
        }
        public async Task PutMovie(int id, Movie movie)
        {
            var exits = MovieExists(id);


            if (!exits)
            {
                throw new MoviesNotFoundException(id);
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> PostMovie(Movie movie)
        {
            _context.MovieOrSeries.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }


        public async Task DeleteMovie(int id)
        {
            var movie = await GetMovie(id);
            if (movie is  null)
            {
                throw new MoviesNotFoundException(id);
            }

            _context.MovieOrSeries.Remove(movie);
            await _context.SaveChangesAsync();
        }

        private bool MovieExists(int id)
        {
            return _context.MovieOrSeries.Any(e => e.Id == id);
        }
    }
}
