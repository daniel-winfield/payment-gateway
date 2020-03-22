namespace Logging.API.Repositories
{
    public interface ILoggingRepository
    {
        void AddLog(Models.Database.Log log);
    }
}
