namespace ReservasAPI.Exceptions
{
    public class DuplicateTimeException : Exception
    {
        public DuplicateTimeException(string message) : base(message)
        {

        }
    }
}
