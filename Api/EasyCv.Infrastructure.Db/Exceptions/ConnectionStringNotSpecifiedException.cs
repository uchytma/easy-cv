namespace EasyCv.Infrastructure.Storage.SQlite.Exceptions
{
    public class ConnectionStringNotSpecifiedException : ApplicationException
    {
        public ConnectionStringNotSpecifiedException()
        {
        }

        public ConnectionStringNotSpecifiedException(string description) : base($"Connection string is not specified. {description}".Trim())
        {
        }
    }
}