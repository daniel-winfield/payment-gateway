using Logging.API.Models;
using Logging.API.Models.Database;
using Logging.API.Repositories;

namespace Logging.API.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _repository;

        public LoggingService(ILoggingRepository repository)
        {
            _repository = repository;
        }

        public void AddLog(LogDto log)
        {
            _repository.AddLog(new Log { LogType = log.LogType, Message = log.Message });
        }
    }
}
