using MediatR;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Get;

public class GetQuesionnairesQuery : IRequest<IQueryable<QuestionnaireDto>>
{
}