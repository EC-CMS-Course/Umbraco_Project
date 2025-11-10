using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Umbraco_Project.ViewModels;

public class QuestionFormViewModel
{
    [Required(ErrorMessage = "Name is reqired")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is reqired")]
    [Display(Name = "Email address")]
    [RegularExpression(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Question is reqired")]
    [Display(Name = "Question")]
    public string Question { get; set; } = null!;

}
