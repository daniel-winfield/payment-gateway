namespace Logging.API.Models.Database
{
    public class Log
    {
        public int LogId { get; set; }

        public string Message { get; set; }

        public LogTypeEnum LogType { get; set; }
    }
}
