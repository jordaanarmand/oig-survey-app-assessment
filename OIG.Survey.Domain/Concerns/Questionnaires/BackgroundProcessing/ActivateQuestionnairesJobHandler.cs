using OIG.Survey.Data.Database;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Domain.Concerns.Questionnaires.BackgroundProcessing;

public interface IActivateQuestionnairesJobHandler
{
    Task Handle(CancellationToken cancellationToken);
}

public class ActivateQuestionnairesJobHandler : IActivateQuestionnairesJobHandler
{
    private readonly DataDbContext _dataDbContext;

    public ActivateQuestionnairesJobHandler(DataDbContext dataDbContext)
    {
        _dataDbContext = dataDbContext;
    }

    public async Task Handle(CancellationToken cancellationToken)
    {
        //TODO: Refactor to use stored proceedure as EF may cause performnace issue at high volumes.
          var scheduledQuestionnaires = _dataDbContext.Set<Questionnaire>()
            .Where(_ => _.QuestionnaireStatusId == (long)Data.Enums.QuestionnaireStatus.Scheduled);

        // TODO: check that there are answers assigned against the questionnaire exclude if count == 0

        foreach (var questionnaire in scheduledQuestionnaires)
            questionnaire.QuestionnaireStatusId = (long)Data.Enums.QuestionnaireStatus.Active;

        await _dataDbContext.SaveChangesAsync(cancellationToken);
    }
}

