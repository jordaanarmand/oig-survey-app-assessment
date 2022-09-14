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
            .NotNull();
            // .GreaterThan(DateTime.Now)
            // .WithMessage("Start Date can not be in the past");

            RuleFor(_ => _.EndDate)
                .NotNull();
            // .GreaterThan(_ => _.StartDate)
            // .WithMessage("End date must be greater than start Date");
    }
}