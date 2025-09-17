using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class QuickMetadataViewerModel : PageModel
{
    [BindProperty] public int DocumentId { get; set; }
    public DocumentDto DocumentMetadata { get; set; }
    public string ErrorMessage { get; set; }

    public async Task OnPostAsync()
    {
        try
        {
            using var client = new HttpClient();
            // Example: Replace with your Relativity REST API URL
            var url = $"https://relativity-host/Relativity.REST/api/Relativity.Objects/workspaces/1012345/documents/{DocumentId}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                DocumentMetadata = await response.Content.ReadFromJsonAsync<DocumentDto>();
            }
            else
            {
                ErrorMessage = $"Document {DocumentId} not found.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error: {ex.Message}";
        }
    }
}

public class DocumentDto
{
    public string ControlNumber { get; set; }
    public string DocumentName { get; set; }
    public string Custodian { get; set; }
}
