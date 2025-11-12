using Azure.Communication.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco_Project.Interfaces;
using Umbraco_Project.Services;
using Umbraco_Project.ViewModels;

namespace Umbraco_Project.Controllers;

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IFormSubmissionService formSubmissionService, IEmailService emailService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
    private readonly IFormSubmissionService _formSubmissionService = formSubmissionService;
    private readonly IEmailService _emailService = emailService;

    public IActionResult HandleCallbackForm(CallbackFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = _formSubmissionService.SaveCallbackRequest(model);
        if (!result)
        {
            TempData["CallbackFormError"] = "Something went wrong while subbmitting your request. Please try again.";
            return RedirectToCurrentUmbracoPage();
        }

        TempData["CallbackFormSuccess"] = "Thank you! Your request has been recieved and we will get back to you soon";

        var emailResult = _emailService.SendEmailConfirmationAsync(model.Email);

        return RedirectToCurrentUmbracoPage();
    }

    public IActionResult HandleQuestionForm(QuestionFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = _formSubmissionService.SaveQuestionFormRequest(model);
        if (!result)
        {
            TempData["QuestionFormError"] = "Something went wrong while subbmitting your question. Please try again.";
            return RedirectToCurrentUmbracoPage();
        }

        TempData["QuestionFormSuccess"] = "Thank you! Your question has been recieved and we will get back to you soon";

        var emailResult = _emailService.SendEmailConfirmationAsync(model.Email);

        return RedirectToCurrentUmbracoPage();
    }

    public IActionResult HandleSupportForm(SupportFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = _formSubmissionService.SaveSupportFormRequest(model);
        if (!result)
        {
            TempData["SupportFormError"] = "Something went wrong. Please try again.";
            return RedirectToCurrentUmbracoPage();
        }

        TempData["SupportFormSuccess"] = "Thank you!";

        var emailResult = _emailService.SendEmailConfirmationAsync(model.Email);

        return RedirectToCurrentUmbracoPage();
    }


}
