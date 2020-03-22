using Microsoft.EntityFrameworkCore;

namespace Logging.API.DataAccess
{
    public class LoggingContext : DbContext
    {
        public LoggingContext(DbContextOptions<LoggingContext> options) : base(options)
        { }

        public DbSet<Logging.API.Models.Database.Log> Logs { get; set; }
    }
}
