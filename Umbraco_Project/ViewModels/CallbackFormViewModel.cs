using System.ComponentModel.DataAnnotations;

namespace Umbraco_Project.ViewModels;

public class CallbackFormViewModel
{
    [Required (ErrorMessage = "Name is reqired")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is reqired")]
    [Display(Name = "Email address")]
    [RegularExpression(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is reqired")]
    [Display(Name = "Phone")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Please select an option")]
    public string SelectedOption { get; set; } = null!;

}
