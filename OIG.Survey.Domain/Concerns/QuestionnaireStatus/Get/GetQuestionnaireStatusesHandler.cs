using MediatR;

namespace OIG.Survey.Domain.Concerns.QuestionnaireStatus.Get;

public class
    GetQuestionnaireStatusesHandler : IRequestHandler<GetQuestionnaireStatusQuery, List<QuestionnaireStatusDto>>
{
    public Task<List<QuestionnaireStatusDto>> Handle(GetQuestionnaireStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = new List<QuestionnaireStatusDto>();

        switch (request.CurrentStatusId)
        {
            case 1:
                result.Add(new QuestionnaireStatusDto
                {
                    Id = 1,
                    Status = Enum.GetName(typeof(Data.Enums.QuestionnaireStatus), 1)
                });
                result.Add(new QuestionnaireStatusDto
                {
                    Id = 2,
                    Status = Enum.GetName(typeof(Data.Enums.QuestionnaireStatus), 2)
                });
                break;
            // User can't set to active, only the background job can
            case 3:
                result.Add(new QuestionnaireStatusDto
                {
                    Id = 3,
                    Status = Enum.GetName(typeof(Data.Enums.QuestionnaireStatus), 3)
                });
                result.Add(new QuestionnaireStatusDto
                {
                    Id = 4,
                    Status = Enum.GetName(typeof(Data.Enums.QuestionnaireStatus), 4)
                });
                break;
            case 4:
                result.Add(new QuestionnaireStatusDto
                {
                    Id = 4,
                    Status = Enum.GetName(typeof(Data.Enums.QuestionnaireStatus), 4)
                });
                break;
        }

        return Task.FromResult(result);
    }
}