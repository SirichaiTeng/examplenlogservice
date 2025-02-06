namespace DotNet_Core_WebApi.IServices
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarn(string message);
        void LogDebug(string message);
    }
}
