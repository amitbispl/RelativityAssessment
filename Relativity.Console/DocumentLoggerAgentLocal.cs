using System;
using System.Data;
using Relativity.API;

public class DocumentLoggerAgentLocal
{
    private readonly IAgentHelper _helper;

    public DocumentLoggerAgentLocal(IAgentHelper helper)
    {
        _helper = helper;
    }

    public void Execute()
    {
        var logger = _helper.GetLoggerFactory().GetLogger();
        var db = _helper.GetDBContext(-1); // -1 = EDDS

        logger.LogInformation("Starting DocumentLoggerAgentLocal at {0}", DateTime.UtcNow);

        try
        {
            string sql = "SELECT ControlNumber, Name FROM Document WHERE CreatedDate > GETDATE()-1";
            DataTable docs = db.ExecuteSqlStatementAsDataTable(sql);

            if (docs.Rows.Count == 0)
            {
                logger.LogInformation("No new documents found.");
                return;
            }

            foreach (DataRow row in docs.Rows)
            {
                string controlNumber = row["ControlNumber"].ToString();
                string name = row["Name"].ToString();

                logger.LogInformation("New Document Found → {0} | {1}", controlNumber, name);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while executing agent logic.");
        }
    }
}
