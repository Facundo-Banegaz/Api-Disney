namespace Api_Disney.Exceptions
{
    public class UsersNotFoundException : Exception
    {
        public UsersNotFoundException(Guid id) : base($"No existe un User con id {id}")
        {

        }

    }
}

