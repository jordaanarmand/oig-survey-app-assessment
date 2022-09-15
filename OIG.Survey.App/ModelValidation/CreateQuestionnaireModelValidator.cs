using FluentValidation;
using OIG_Survey_App.Models;

namespace OIG_Survey_App.ModelValidation;

public class CreateQuestionnaireModelValidator : AbstractValidator<CreateQuestionnaireModel>
{
    public CreateQuestionnaireModelValidator()
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
            .GreaterThan(_ => DateTime.Now).WithMessage("End date can no be less than current date time")
            ;
    }
}