namespace Api_Disney.Exceptions
{
    public class GenreAlreadyExistsException: Exception
    {
        public GenreAlreadyExistsException(string name) : base($"El género '{name}' ya existe.")
        {
        }
    }
}
