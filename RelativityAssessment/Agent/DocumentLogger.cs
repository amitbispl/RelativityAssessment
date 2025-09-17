using System;
using System.Data;
using System.Data.SqlClient;
using Relativity.API;
using kCura.Agent;

namespace Relativity.CustomAgents
{
    [kCura.Agent.CustomAttributes.Name("Document Logger Agent")]
    [System.Runtime.InteropServices.Guid("3CBA39E4-0F45-45F3-9B88-777777777777")]
    public class DocumentLoggerAgent : AgentBase
    {
        public override string Name => "Document Logger Agent";

        public override void Execute()
        {
            var logger = Helper.GetLoggerFactory().GetLogger();

            try
            {
                int workspaceId = 1;
                logger.LogInformation("Agent started in workspace {workspaceId}", workspaceId);

                IDBContext dbContext = Helper.GetDBContext(workspaceId);

                // Fetch 5 documents
                string selectSql = "SELECT TOP 5 [ControlNumber], [ArtifactID], [Name] " +
                                   "FROM [Document] WITH (NOLOCK) ORDER BY [ArtifactID] DESC";

                DataTable docs = dbContext.ExecuteSqlStatementAsDataTable(selectSql);

                foreach (DataRow row in docs.Rows)
                {
                    string controlNumber = row["ControlNumber"].ToString();
                    string docName = row["Name"].ToString();

                    // Use parameterized SQL to avoid injection
                    string insertSql = @"
                        INSERT INTO Z_DocumentLogger (ControlNumber, DocumentName, CreatedOn)
                        VALUES (@ControlNumber, @DocumentName, @CreatedOn)";

                    var parameters = new[]
                    {
                        new SqlParameter("@ControlNumber", SqlDbType.NVarChar) { Value = controlNumber },
                        new SqlParameter("@DocumentName", SqlDbType.NVarChar) { Value = docName },
                        new SqlParameter("@CreatedOn", SqlDbType.DateTime) { Value = DateTime.UtcNow }
                    };

                    dbContext.ExecuteNonQuerySQLStatement(insertSql, parameters);

                    logger.LogInformation("Inserted {controlNumber}", controlNumber);
                }

                logger.LogInformation("Agent finished.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in DocumentLoggerAgent.");
                RaiseError(ex.ToString(), ex.Message);
            }
        }
    }
}
