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
using Api_Disney.DTOs;
using Api_Disney.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace Api_Disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersServices _services;

        public CharactersController(ICharactersServices services)
        {
            _services = services;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _services.GetCharacters();
        }

        [HttpGet("filter")]

        //[Authorize] // Necesita token para acceder
        public async Task<ActionResult<IEnumerable<Character>>> FilterCharacters( 
            [FromQuery] string? name=null,
            [FromQuery] DateTime? age= null,
            [FromQuery] float? weight = null,
            [FromQuery] string? movies = null
            )
        {
            // Llamar al servicio para obtener los personajes filtrados
            var characters = await _services.GetCharactersFilter(name, age, weight, movies);

            // Retornar los personajes filtrados 
            return Ok(characters);
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(Guid id)
        {
            var character = await _services.GetCharacter(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(Guid id, CharacterDTO character)
        {
            try
            {
                var personaje = character.ToCharacter();
                personaje.Id = id;
                await _services.PutCharacter(id, personaje);
            }
            catch (CharactersNotFoundException ex)
            {
                return NotFound(ex.Message);

            }

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterDTO character)
        {
            var createCharacter = await _services.PostCharacter(character.ToCharacter());

            return CreatedAtAction(nameof(GetCharacter), new { id = createCharacter.Id }, createCharacter);


        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(Guid id)
        {
            try
            {
                await _services.DeleteCharacter(id);
            }
            catch (CharactersNotFoundException ex)
            {

                return NotFound(ex.Message);
            }

            return NoContent();
        }

    }

}

