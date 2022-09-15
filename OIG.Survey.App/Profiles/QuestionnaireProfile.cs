using AutoMapper;
using OIG_Survey_App.Models;
using OIG.Survey.Domain.Concerns.Questionnaires;
using OIG.Survey.Domain.Concerns.Questionnaires.Create;
using OIG.Survey.Domain.Concerns.Questionnaires.Edit;

namespace OIG_Survey_App.Profiles;

public class QuestionnaireModelProfile: Profile
{
    public QuestionnaireModelProfile()
    {
        CreateMap<CreateQuestionnaireModel, CreateQuestionnaireCommand>();
        CreateMap<EditQuestionnaireModel, EditQuestionnaireCommand>();
        
        // CreateMap<QuestionnaireModel, <IQueryable<QuestionnaireDto>>();
    }
}