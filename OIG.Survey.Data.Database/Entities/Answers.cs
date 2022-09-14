namespace OIG.Survey.Data.Database.Entities;

public class Answers
{
    public long Id { get; set; }

    public long QuestionnaireId { get; set; }

    public virtual Questionnaire Questionnaire { get; set; }

    public long QuestionsId { get; set; }

    public virtual Questions Questions { get; set; }

    public long RespondentId { get; set; }

    public virtual Respondent Respondent { get; set; }

    public DateTime DateCreated { get; set; }

    public string Answer { get; set; }
}