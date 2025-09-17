using System;

namespace Relativity.Fake
{
    public interface ILoggerFactory
    {
        ILogger GetLogger();
    }

    public interface ILogger
    {
        void LogInformation(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
    }
}
