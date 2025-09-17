using Relativity.API;
using System;

public class FakeHelper : IAgentHelper
{
    private readonly ILogFactory _loggerFactory = new FakeLoggerFactory();
    private readonly IDBContext _dbContext = new FakeDBContext();

    public ILogFactory GetLoggerFactory()
    {
        return _loggerFactory;
    }

    public IDBContext GetDBContext(int workspaceId)
    {
        // workspaceId ignored here since we’re simulating
        return _dbContext;
    }

    public IAuthenticationMgr GetAuthenticationManager()
    {
        throw new NotImplementedException();
    }

    public IServicesMgr GetServicesManager()
    {
        throw new NotImplementedException();
    }

    public IUrlHelper GetUrlHelper()
    {
        throw new NotImplementedException();
    }

    public string ResourceDBPrepend()
    {
        throw new NotImplementedException();
    }

    public string ResourceDBPrepend(IDBContext context)
    {
        throw new NotImplementedException();
    }

    public string GetSchemalessResourceDataBasePrepend(IDBContext context)
    {
        throw new NotImplementedException();
    }

    public Guid GetGuid(int workspaceID, int artifactID)
    {
        throw new NotImplementedException();
    }

    public ISecretStore GetSecretStore()
    {
        throw new NotImplementedException();
    }

    public IInstanceSettingsBundle GetInstanceSettingBundle()
    {
        throw new NotImplementedException();
    }

    public IStringSanitizer GetStringSanitizer(int workspaceID)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // no-op for fake
    }
}
