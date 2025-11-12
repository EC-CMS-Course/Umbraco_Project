using System.ComponentModel.DataAnnotations;

namespace Umbraco_Project.Models;

public class SendEmailRequest
{
    [Required]
    public string? Email { get; set; } = null;
}
