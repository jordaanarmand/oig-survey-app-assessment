namespace OIG.Survey.Data.Database.Entities;

public class Questionnaire
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public long QuestionnaireStatusId { get; set; }

    public virtual QuestionnaireStatus QuestionnaireStatus { get; set; }

    public virtual List<Questions> Questions { get; set; }
}