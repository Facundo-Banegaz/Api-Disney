namespace Api_Disney.Exceptions
{
    public class CharactersNotFoundException : Exception
    {
        public CharactersNotFoundException(int id) : base($"No existe un Personaje con id {id}")
        {

        }
    }
}
