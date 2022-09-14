using MediatR;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Create;

public class CreateQuestionnaireCommand : IRequest<long>
{
    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}