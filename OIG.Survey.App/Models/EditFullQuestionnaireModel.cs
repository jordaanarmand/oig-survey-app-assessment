namespace OIG_Survey_App.Models;

public class EditFullQuestionnaireModel
{
    public EditQuestionnaireModel QuestionnaireModel { get; set; }

    public List<QuestionnaireStatusModel> StatusModels { get; set; }
}