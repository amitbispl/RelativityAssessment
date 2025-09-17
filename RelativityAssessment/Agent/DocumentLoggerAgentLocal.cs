using Relativity.API;
using System.Data;

public class DocumentLoggerAgentLocal
{
    private readonly IHelper _helper;
    public DocumentLoggerAgentLocal(IHelper helper)
    {
        _helper = helper;
    }

    public void Execute()
    {
        var logger = _helper.GetLoggerFactory().GetLogger();
        var db = _helper.GetDBContext(12345);

        var docs = db.ExecuteSqlStatementAsDataTable("SELECT ...");

        foreach (DataRow row in docs.Rows)
        {
            logger.LogInformation("Document {0} - {1}", row["ControlNumber"], row["Name"]);
        }
    }
}
