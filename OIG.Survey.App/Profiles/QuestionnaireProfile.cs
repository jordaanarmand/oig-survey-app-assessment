using AutoMapper;
using OIG_Survey_App.Models;
using OIG.Survey.Domain.Concerns.Questionnaires;
using OIG.Survey.Domain.Concerns.Questionnaires.Create;

namespace OIG_Survey_App.Profiles;

public class QuestionnaireModelProfile: Profile
{
    public QuestionnaireModelProfile()
    {
        CreateMap<CreateQuestionnaireModel, CreateQuestionnaireCommand>();
        // CreateMap<QuestionnaireModel, <IQueryable<QuestionnaireDto>>();
    }
}