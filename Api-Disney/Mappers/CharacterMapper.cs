
using Api_Disney.DTOs;
using Api_Disney.Models;

namespace Api_Disney.Mappers
{
    public static class CharacterMapper
    {

        public static Character ToCharacter(this CharacterDTO character)
        {
            return new Character
            {
                Nombre = character.Nombre,
                Imagen = character.Imagen,
                FechaCreacion = character.FechaCreacion,
                Peso = character.Peso,
                Historia = character.Historia
            };

        }
    }
}
