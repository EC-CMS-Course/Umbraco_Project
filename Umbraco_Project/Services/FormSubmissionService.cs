using System.Diagnostics;
using Umbraco.Cms.Core.Services;
using Umbraco_Project.Interfaces;
using Umbraco_Project.ViewModels;

namespace Umbraco_Project.Services;

public class FormSubmissionService(IContentService contentService) : IFormSubmissionService
{
    private readonly IContentService _contentService = contentService;
   

    public bool SaveCallbackRequest(CallbackFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool SaveQuestionFormRequest(QuestionFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "questionFormSubmissions");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "questionFormRequest");

            request.SetValue("questionFormRequestName", model.Name);
            request.SetValue("questionFormRequestEmail", model.Email);
            request.SetValue("questionFormRequestQuestion", model.Question);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool SaveSupportFormRequest(SupportFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "supportFormSubmissions");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Email}";
            var request = _contentService.Create(requestName, container, "supportFormRequest");

            request.SetValue("supportFormRequestEmail", model.Email);

            var saveResult = _contentService.Save(request);
            return saveResult.Success;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
