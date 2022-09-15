using MediatR;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Edit;

public class EditQuestionnaireCommand : IRequest<long>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public long StatusId { get; set; }
}