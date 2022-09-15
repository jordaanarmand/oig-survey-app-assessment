using FluentValidation;
using OIG_Survey_App.Models;

namespace OIG_Survey_App.ModelValidation;

public class EditQuestionnaireModelValidator : AbstractValidator<EditFullQuestionnaireModel>
{
    public EditQuestionnaireModelValidator()
    {
        RuleFor(_ => _.QuestionnaireModel.Name)
            .NotEmpty()
            ;

        RuleFor(_ => _.QuestionnaireModel.StartDate)
            .NotNull()
            .LessThan(_ => _.QuestionnaireModel.EndDate).WithMessage("Start date can not be greater than end date")
            .GreaterThan(DateTime.Now.ToLocalTime()).WithMessage("Start date can not be less than current date time")
            ;

        RuleFor(_ => _.QuestionnaireModel.EndDate)
            .NotNull()
            .GreaterThan(_ => _.QuestionnaireModel.StartDate).WithMessage("End date can not be less than start date")
            .GreaterThan(_ => DateTime.Now).WithMessage("End date can no be less than current date time")
            ;
    }
}