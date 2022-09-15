using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OIG.Survey.Data.Database;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Close;

public class CloseQuestionnaireHandler : IRequestHandler<CloseQuestionnaireCommand, long>
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;

    public CloseQuestionnaireHandler(DataDbContext dataDbContext, IMapper mapper)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(CloseQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dataDbContext.Set<Questionnaire>()
            .FirstOrDefaultAsync(_ => _.Id == request.Id &&
                                      _.QuestionnaireStatusId == (long)Data.Enums.QuestionnaireStatus.Active,
                cancellationToken);

        if (entity is null)
        {
            throw new KeyNotFoundException(
                $"A questionnaire with the id {request.Id} and status Active could not be found");
        }

        // TODO: Ask about if we can introduced a closed state instead of using the finished state.
        entity.QuestionnaireStatusId = (long)Data.Enums.QuestionnaireStatus.Finished;

        await _dataDbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}