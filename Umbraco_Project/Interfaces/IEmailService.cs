using Umbraco_Project.Models;

namespace Umbraco_Project.Interfaces;

public interface IEmailService
{
    Task<EmailServiceResult> SendEmailConfirmationAsync(string email);
}
