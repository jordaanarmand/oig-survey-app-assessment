using MediatR;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Close;

public record CloseQuestionnaireCommand(long Id) : IRequest<long>
{
}