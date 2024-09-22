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
        public async Task<Movie?> GetMovie(Guid id)
        {
            return await _context.MovieOrSeries
        .Include(m => m.Characters)      // Incluir los personajes relacionados con la película
        .Include(m => m.Genero)           // Incluir el género relacionado con la película
        .FirstOrDefaultAsync(m => m.Id == id);


        }
        public async Task PutMovie(Guid id, Movie movie)
        {
            var exits =await MovieExistsAsync(id);


            if (!exits)
            {
                throw new MoviesNotFoundException(id);
            }

            var duplicateMovie = await _context.MovieOrSeries
                                    .AnyAsync(m => m.Titulo == movie.Titulo && m.GeneroId == movie.GeneroId && m.Id != id);

            if (duplicateMovie)
            {
                throw new MovieAlreadyExistsException(movie.Titulo, movie.Genero?.Nombre ?? "desconocido");
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> PostMovie(Movie movie)
        {
            // Verificar si ya existe una película con el mismo título y género
            var exists = await _context.MovieOrSeries
                                       .AnyAsync(m => m.Titulo == movie.Titulo && m.GeneroId == movie.GeneroId);

            if (exists)
            {
                throw new MovieAlreadyExistsException(movie.Titulo, movie.Genero?.Nombre ?? "desconocido"); // Excepción personalizada
            }

            _context.MovieOrSeries.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }


        public async Task DeleteMovie(Guid id)
        {
            var movie = await GetMovie(id);
            if (movie is  null)
            {
                throw new MoviesNotFoundException(id);
            }

            _context.MovieOrSeries.Remove(movie);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> MovieExistsAsync(Guid id)
        {
            return await _context.MovieOrSeries.AnyAsync(e => e.Id == id);
        }


        public async Task<List<Movie>> GetMoviesFilter(string? name, string? genre, string? order)
        {
            // Comenzar con una consulta base
            var query =  _context.MovieOrSeries.Include(g => g.Genero).AsQueryable();
            // Filtrar por nombre de película
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Titulo.ToLower().Contains(name.ToLower()));
            }

            // Filtrar por género
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(m => m.Genero.Nombre.ToLower().Contains(genre.ToLower()));
            }

            // Ordenar por nombre (o cualquier otro campo que necesites)
            if (string.Equals(order, "desc", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(m => m.Id); // id
            }
            else
            {
                query = query.OrderBy(m => m.Id); // Orden ascendente por defecto
            }

            // Ejecutar la consulta y devolver la lista filtrada
            return await query.ToListAsync();
        }
    }
}
