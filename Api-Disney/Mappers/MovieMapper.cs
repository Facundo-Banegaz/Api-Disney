using Api_Disney.DTOs;
using Api_Disney.Models;

namespace Api_Disney.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToMovie(this MovieDTO movie)
        {
            return new Movie
            {
                Titulo = movie.Titulo,
                Imagen = movie.Imagen,
                FechaCreacion = movie.FechaCreacion,
                GeneroId = movie.GeneroId,
                Calification = movie.Calification,
            };
        }
    }
}
