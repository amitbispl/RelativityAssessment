using Relativity.API;
using System;

public class FakeLogger : IAPILog
{
    public void LogDebug(string message) => Console.WriteLine("[DEBUG] " + message);
    public void LogInformation(string message) => Console.WriteLine("[INFO] " + message);
    public void LogWarning(string message) => Console.WriteLine("[WARN] " + message);
    public void LogError(string message) => Console.WriteLine("[ERROR] " + message);
    public void LogError(Exception ex, string message) =>
        Console.WriteLine($"[ERROR] {message}: {ex.Message}");

    // Overloads with args
    public void LogInformation(string message, params object[] args) =>
        Console.WriteLine("[INFO] " + string.Format(message, args));

    public void LogWarning(string message, params object[] args) =>
        Console.WriteLine("[WARN] " + string.Format(message, args));

    public void LogError(Exception ex, string message, params object[] args) =>
        Console.WriteLine($"[ERROR] {string.Format(message, args)}: {ex.Message}");

    public void LogDebug(string message, params object[] args) =>
        Console.WriteLine("[DEBUG] " + string.Format(message, args));

    public void LogVerbose(string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogVerbose(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogDebug(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogInformation(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogWarning(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogError(string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogFatal(string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogFatal(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public IAPILog ForContext<T>()
    {
        throw new NotImplementedException();
    }

    public IAPILog ForContext(Type source)
    {
        throw new NotImplementedException();
    }

    public IAPILog ForContext(string propertyName, object value, bool destructureObjects)
    {
        throw new NotImplementedException();
    }

    public IDisposable LogContextPushProperty(string propertyName, object obj)
    {
        throw new NotImplementedException();
    }
}

public class FakeLoggerFactory : ILogFactory
{
    private readonly IAPILog _logger = new FakeLogger();

    public IAPILog GetLogger()
    {
        return _logger;
    }
}
