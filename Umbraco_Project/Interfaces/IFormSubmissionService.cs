using Umbraco_Project.ViewModels;

namespace Umbraco_Project.Interfaces
{
    public interface IFormSubmissionService
    {
        bool SaveCallbackRequest(CallbackFormViewModel model);
        bool SaveQuestionFormRequest(QuestionFormViewModel model);
        bool SaveSupportFormRequest(SupportFormViewModel model);
    }
}