using FluentValidation;
using OIG_Survey_App.Models;

namespace OIG_Survey_App.ModelValidation;

public class EditQuestionnaireModelValidator : AbstractValidator<EditQuestionnaireModel>
{
    public EditQuestionnaireModelValidator()
    {
        RuleFor(_ => _.Name)
            .NotEmpty();

        RuleFor(_ => _.StartDate)
            .NotNull()
            .LessThan(_ => _.EndDate).WithMessage("Start date can not be greater than end date")
            .GreaterThan(DateTime.Now.ToLocalTime()).WithMessage("Start date can not be less than current date time")
            ;

        RuleFor(_ => _.EndDate)
            .NotNull()
            .GreaterThan(_ => _.StartDate).WithMessage("End date can not be less than start date")
            .GreaterThan(_ => DateTime.Now).WithMessage("End date cna no be less than current date time")
            ;
    }
}