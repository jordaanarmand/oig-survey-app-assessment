using AutoMapper;
using OIG.Survey.Domain.Concerns.Questionnaires.Create;
using QuestionnaireEntity = OIG.Survey.Data.Database.Entities.Questionnaire;

namespace OIG.Survey.Domain.Concerns.Questionnaires;

public class QuestionnaireProfile : Profile
{
    public QuestionnaireProfile()
    {
        CreateMap<QuestionnaireDto, QuestionnaireEntity>()
            .ReverseMap();
        CreateMap<CreateQuestionnaireCommand, QuestionnaireEntity>();
    }
}