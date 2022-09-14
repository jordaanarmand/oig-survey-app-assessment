using MediatR;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Delete;

public record DeleteQuestionnaireCommand(long Id) : IRequest<long>;