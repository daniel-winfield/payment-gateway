using Logging.API.DataAccess;
using Logging.API.Models.Database;

namespace Logging.API.Repositories
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly LoggingContext _context;

        public LoggingRepository(LoggingContext context)
        {
            _context = context;
        }

        public void AddLog(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
