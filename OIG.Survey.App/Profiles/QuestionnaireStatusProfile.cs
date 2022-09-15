using AutoMapper;
using OIG_Survey_App.Models;
using OIG.Survey.Domain.Concerns.QuestionnaireStatus;

namespace OIG_Survey_App.Profiles;

public class QuestionnaireStatusProfile : Profile
{
    public QuestionnaireStatusProfile()
    {
        CreateMap<QuestionnaireStatusDto, QuestionnaireStatusModel>();

    }
}