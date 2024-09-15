namespace Api_Disney.Exceptions
{
    public class CharacterAlreadyExistsException: Exception
    {
        public CharacterAlreadyExistsException(string name) : base($"El personaje con el nombre '{name}' ya existe.")
        {
        }
    }
}
