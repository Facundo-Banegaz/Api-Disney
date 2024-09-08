using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Disney.Data;
using Api_Disney.Models;
using Api_Disney.DTOs;
using Api_Disney.Services;
using Api_Disney.Services.Interfaces;
using Api_Disney.Exceptions;
using Api_Disney.Mapper;

namespace Api_Disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreServices _services;

        public GenresController(IGenreServices services)
        {
            _services = services;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _services.GetGenres();

        }




        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _services.GetGenre(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, GenreDTO genre)
        {
           

            try
            {
                var genero = genre.TOGenre();
                genero.Id = id;

                await _services.PutGenre(id ,genero);
            }
            catch (GenreNotFoundException ex)
            {
                return NotFound(ex.Message);
                
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(GenreDTO genre)
        {

           var createGenre = await _services.PostGenre(genre.TOGenre());


            return CreatedAtAction(nameof(GetGenre), new { id = createGenre.Id }, createGenre); ;
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {


            try
            {
                await _services.DeleteGenre(id);
            }
            catch (GenreNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return NoContent();
        }

    }
}
