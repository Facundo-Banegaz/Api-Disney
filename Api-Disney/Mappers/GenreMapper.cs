using Api_Disney.DTOs;
using Api_Disney.Models;

namespace Api_Disney.Mapper
{   
    public static class GenreMapper
    {

        public static Genre TOGenre(this GenreDTO genre)
        {

            return new Genre
            {
                Nombre = genre.Nombre
            };
        }
    }
}
