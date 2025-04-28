namespace MovieRental.Exception
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _delegate;
        private readonly ILookup<ExceptionHandler> _logger;
    }
}
