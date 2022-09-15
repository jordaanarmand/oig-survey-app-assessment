using MediatR;

namespace OIG.Survey.Domain.Concerns.QuestionnaireStatus.Get;

public record GetQuestionnaireStatusQuery(long CurrentStatusId) : IRequest<List<QuestionnaireStatusDto>>
{
}