namespace Api_Disney.Exceptions
{
    public class MoviesNotFoundException: Exception
    {
        public MoviesNotFoundException(int id) : base($"No existe una pelicula con id {id}")
        {

        }
    }
}
