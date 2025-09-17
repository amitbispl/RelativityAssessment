using System;
using System.Data;
using System.Data.SqlClient;
using Relativity.API;

public class FakeHelper : IHelper
{
    private readonly int _workspaceId;

    public FakeHelper(int workspaceId)
    {
        _workspaceId = workspaceId;
    }

    public void Dispose()
    {
        // Nothing to dispose in local
    }

    public IDBContext GetDBContext(int workspaceId)
    {
        // Create a local DBContext substitute
        return new FakeDBContext();
    }

    public ILogFactory GetLoggerFactory()
    {
        return new FakeLogFactory();
    }

    // Other IHelper members can throw NotImplementedException
    public Guid GetGuid(int workspaceID, int artifactID) => Guid.NewGuid();
    public IInstanceSettingsBundle GetInstanceSettingBundle() => throw new NotImplementedException();
    public string GetSchemalessResourceDataBasePrepend(IDBContext context) => throw new NotImplementedException();
    public ISecretStore GetSecretStore() => throw new NotImplementedException();
    public IServicesMgr GetServicesManager() => throw new NotImplementedException();
    public IStringSanitizer GetStringSanitizer(int workspaceID) => throw new NotImplementedException();
    public IUrlHelper GetUrlHelper() => throw new NotImplementedException();
    public string ResourceDBPrepend() => throw new NotImplementedException();
    public string ResourceDBPrepend(IDBContext context) => throw new NotImplementedException();
}
