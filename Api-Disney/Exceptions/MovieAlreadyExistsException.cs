namespace Api_Disney.Exceptions
{
    public class MovieAlreadyExistsException : Exception
    {
        public MovieAlreadyExistsException(string title, string genre)
            : base($"Ya existe una película con el título '{title}' y género '{genre}'.")
        {
        }
    
    }
}
