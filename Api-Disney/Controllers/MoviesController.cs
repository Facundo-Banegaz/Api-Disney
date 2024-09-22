using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Disney.Data;
using Api_Disney.Models;
using Api_Disney.Services.Interfaces;
using Api_Disney.Exceptions;
using Humanizer.Localisation;
using Api_Disney.DTOs;
using Api_Disney.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace Api_Disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesServices _services;

        public MoviesController(IMoviesServices services)
        {
            _services = services;
        }

        // GET: api/Movies
        [HttpGet]
        [Authorize(Roles = "Usuario, Administrator")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieOrSeries()
        {
            return await _services.GetMovieOrSeries();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Usuario, Administrator")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var movie = await _services.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutMovie(Guid id, MovieDTO movie)
        {
            try
            {
                var pelicula = movie.ToMovie();
                pelicula.Id = id;
                await _services.PutMovie(id, pelicula);
            }
            catch (MoviesNotFoundException ex)
            {
                return NotFound(ex.Message);

            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Movie>> PostMovie(MovieDTO movie)
        {
            var createMovie = await _services.PostMovie(movie.ToMovie());

            return CreatedAtAction(nameof(GetMovie), new { id = createMovie.Id }, createMovie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            try
            {
                await _services.DeleteMovie(id);
            }
            catch (MoviesNotFoundException ex)
            {

                return NotFound(ex.Message);
            }

            return NoContent();
        }


        [HttpGet("filter")]
        [Authorize(Roles = "Usuario, Administrator")]
        public async Task<ActionResult<IEnumerable<Movie>>> FilterMovies(
            [FromQuery] string? name = null,
            [FromQuery] string? genre = null, 
            [FromQuery] string order = "asc"
            )
        {

            // Llamar al servicio para obtener las películas filtradas
            var peliculas = await _services.GetMoviesFilter(name, genre, order);

            // Retornar las películas filtradas
            return Ok(peliculas);
        }
    }
}
