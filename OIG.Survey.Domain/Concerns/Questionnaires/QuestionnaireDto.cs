using OIG.Survey.Data.Enums;

namespace OIG.Survey.Domain.Concerns.Questionnaires;

public class QuestionnaireDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public long QuestionnaireStatusId { get; set; }
}