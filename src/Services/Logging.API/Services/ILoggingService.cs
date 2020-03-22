using Logging.API.Models;

namespace Logging.API.Services
{
    public interface ILoggingService
    {
        void AddLog(LogDto log);
    }
}
