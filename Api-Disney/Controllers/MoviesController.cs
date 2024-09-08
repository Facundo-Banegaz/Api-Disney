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

namespace Api_Disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesServices _services;

        public MoviesController(IMoviesServices services)
        {
            _services = services;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieOrSeries()
        {
            return await _services.GetMovieOrSeries();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
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
        public async Task<IActionResult> PutMovie(int id, MovieDTO movie)
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
        public async Task<ActionResult<Movie>> PostMovie(MovieDTO movie)
        {
            var createMovie = await _services.PostMovie(movie.ToMovie());

            return CreatedAtAction(nameof(GetMovie), new { id = createMovie.Id }, createMovie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
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


    }
}
