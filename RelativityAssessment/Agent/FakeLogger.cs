using Relativity.API;
using System;

public class FakeLogFactory : ILogFactory
{
    public IAPILog GetLogger() => new FakeLogger();
}

public class FakeLogger : IAPILog
{
    public void LogInformation(string message, params object[] args) => Console.WriteLine("[INFO] " + string.Format(message, args));
    public void LogError(Exception ex, string message, params object[] args) => Console.WriteLine("[ERROR] " + string.Format(message, args) + " Exception: " + ex.Message);

    public void LogVerbose(string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogVerbose(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogDebug(string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogDebug(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogWarning(string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogWarning(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }

    public void LogError(string messageTemplate, params object[] propertyValues)
    {
        Console.WriteLine("[ERROR] " + string.Format(messageTemplate, propertyValues) + " Exception: " + ex.Message);
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

    public void LogInformation(Exception exception, string messageTemplate, params object[] propertyValues)
    {
        throw new NotImplementedException();
    }
}
