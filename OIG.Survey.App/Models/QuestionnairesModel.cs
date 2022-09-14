using OIG.Survey.Domain.Concerns.Questionnaires;

namespace OIG_Survey_App.Models;

public class QuestionnairesModel
{
    public IQueryable<QuestionnaireDto> Questionnaires { get; set; }
}