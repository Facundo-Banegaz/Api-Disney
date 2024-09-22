namespace Api_Disney.Exceptions
{
    public class CharactersNotFoundException : Exception
    {
        public CharactersNotFoundException(Guid id) : base($"No existe un Personaje con id {id}")
        {

        }
    }
}
