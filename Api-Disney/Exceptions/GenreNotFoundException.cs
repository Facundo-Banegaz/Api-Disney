namespace Api_Disney.Exceptions
{
    public class GenreNotFoundException: Exception
    {
        public GenreNotFoundException(int id) : base($"No existe un Genero con id {id}")
        {

        }
    }
}
