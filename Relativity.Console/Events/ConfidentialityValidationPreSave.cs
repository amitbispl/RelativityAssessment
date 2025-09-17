using kCura.EventHandler;
using Relativity.API;
using System;

namespace Relativity.EventHandlers
{
    [kCura.EventHandler.CustomAttributes.Description("Validate Confidentiality and Reviewer Notes")]
    public class ConfidentialityValidationPreSave : PreSaveEventHandler
    {
        public override FieldCollection RequiredFields
        {
            get
            {
                var fields = new FieldCollection
                {
                    // Mark required fields for this event handler
                    this.ActiveArtifact.Fields["Confidentiality"],
                    this.ActiveArtifact.Fields["Attorney Review Comments"]
                };
                return fields;
            }
        }

        public override Response Execute()
        {
            var response = new Response();

            try
            {
                // Convert values safely
                string confidentiality = this.ActiveArtifact.Fields["Confidentiality"].Value?.Value?.ToString();
                string reviewerNotes = this.ActiveArtifact.Fields["Attorney Review Comments"].Value?.Value?.ToString();

                if (string.Equals(confidentiality, "Confidential", StringComparison.OrdinalIgnoreCase)
                    && string.IsNullOrWhiteSpace(reviewerNotes))
                {
                    response.Success = false;
                    response.Message = "Reviewer Notes are required for confidential documents.";
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Validation failed: " + ex.Message;
            }

            return response;
        }
    }
}
