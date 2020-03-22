namespace Logging.API.DataAccess
{
    public static class DbInitialiser
    {
        public static void Initialise(LoggingContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
