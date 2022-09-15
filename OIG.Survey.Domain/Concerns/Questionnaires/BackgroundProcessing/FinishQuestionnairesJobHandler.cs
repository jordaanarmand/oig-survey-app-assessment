using OIG.Survey.Data.Database;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Domain.Concerns.Questionnaires.BackgroundProcessing;

public interface IFinishQuestionnairesJobHandler
{
    Task Handle(CancellationToken cancellationToken);
}

public class FinishQuestionnairesJobHandler : IFinishQuestionnairesJobHandler
{
    private readonly DataDbContext _dataDbContext;

    public FinishQuestionnairesJobHandler(DataDbContext dataDbContext)
    {
        _dataDbContext = dataDbContext;
    }

    public async Task Handle(CancellationToken cancellationToken)
    {
        var scheduledQuestionnaires = _dataDbContext.Set<Questionnaire>()
            .Where(_ => _.QuestionnaireStatusId == (long)Data.Enums.QuestionnaireStatus.Active &&
                        _.EndDate.ToLocalTime() < DateTime.Now.ToLocalTime());

        foreach (var questionnaire in scheduledQuestionnaires)
            questionnaire.QuestionnaireStatusId = (long)Data.Enums.QuestionnaireStatus.Finished;

        await _dataDbContext.SaveChangesAsync(cancellationToken);
    }
}