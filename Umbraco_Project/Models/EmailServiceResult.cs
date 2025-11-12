namespace Umbraco_Project.Models;

public class EmailServiceResult
{
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}
