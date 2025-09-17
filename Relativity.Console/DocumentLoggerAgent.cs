using System;
using System.IO;
using kCura.Agent;
using Relativity.API;

namespace Relativity.Agents
{
    [kCura.Agent.CustomAttributes.Name("Document Logger Agent")]
    [System.Runtime.InteropServices.Guid("E2A22222-3333-4444-5555-666677778888")]
    public class DocumentLoggerAgent : AgentBase
    {
        public override string Name => "Document Logger Agent";
        private readonly IAgentHelper _helper;

        public DocumentLoggerAgent(IAgentHelper helper)
        {
            _helper = helper;
        }
        public override void Execute()
        {
            var logger = Helper.GetLoggerFactory().GetLogger();
            logger.LogInformation("Document Logger Agent started at {0}", DateTime.UtcNow);

            try
            {
                var dbContext = Helper.GetDBContext(-1);

                // Example: Get docs added in last 5 minutes
                string sql = @"
                    SELECT TOP 1000 TextIdentifier AS ControlNumber, ExtractedText AS DocumentName
                    FROM EDDSDBO.Document WITH (NOLOCK)
                    WHERE CreatedOn >= DATEADD(MINUTE, -5, GETUTCDATE())";

                var reader = dbContext.ExecuteSQLStatementAsReader(sql);
                var file = new StreamWriter(@"C:\RelativityLogs\DocLogger.csv", true);

                if (!reader.HasRows)
                {
                    logger.LogInformation("No new documents found.");
                }

                while (reader.Read())
                {
                    string cn = reader["ControlNumber"].ToString();
                    string dn = reader["DocumentName"].ToString();

                    file.WriteLine($"{DateTime.UtcNow},{cn},{dn}");
                    logger.LogInformation("New doc logged: {0}, {1}", cn, dn);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error running Document Logger Agent");
                RaiseError(ex.ToString(), ex.Message);
            }

            logger.LogInformation("Document Logger Agent finished at {0}", DateTime.UtcNow);
        }
    }
}
