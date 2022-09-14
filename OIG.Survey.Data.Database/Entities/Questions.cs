namespace OIG.Survey.Data.Database.Entities;

public class Questions
{
    public long Id { get; set; }

    public string Question { get; set; }

    public long QuestionTypeId { get; set; }

    public virtual QuestionType QuestionType { get; set; }

    public IEnumerable<long> QuestionOptionId { get; set; }

    public virtual IEnumerable<QuestionOption> QuestionOption { get; set; }
}