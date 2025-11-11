using System.ComponentModel.DataAnnotations;

namespace Umbraco_Project.ViewModels;

public class SupportFormViewModel
{
    [Required(ErrorMessage = "Email is reqired")]
    [Display(Name = "E-mail address")]
    [RegularExpression(
      @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
      ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;
}
