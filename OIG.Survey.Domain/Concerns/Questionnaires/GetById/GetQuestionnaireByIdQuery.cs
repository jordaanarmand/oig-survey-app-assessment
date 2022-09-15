using MediatR;

namespace OIG.Survey.Domain.Concerns.Questionnaires.GetById;

public record GetQuestionnaireByIdQuery(long Id) : IRequest<QuestionnaireDto>
{
}