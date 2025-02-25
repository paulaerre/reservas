namespace ReservasAPI.Exceptions
{
    public class DuplicateClientPerDayException : Exception
    {
        public DuplicateClientPerDayException(string message) : base(message)
        {

        }
    }
}
