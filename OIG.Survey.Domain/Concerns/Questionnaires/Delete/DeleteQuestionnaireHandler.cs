using System.ComponentModel;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OIG.Survey.Data.Database;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Delete;

public class DeleteQuestionnaireHandler : IRequestHandler<DeleteQuestionnaireCommand, long>
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;

    public DeleteQuestionnaireHandler(DataDbContext dataDbContext, IMapper mapper)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(DeleteQuestionnaireCommand command, CancellationToken cancellationToken)
    {
        //TODO: Can move this into a fluentvalidator
        var entity = await _dataDbContext.Set<Questionnaire>()
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id == command.Id, cancellationToken);

        if (entity is null) throw new NullReferenceException("A questionnaire with this id could not be found");

        if (entity.QuestionnaireStatusId != (long)Data.Enums.QuestionnaireStatus.Concept)
            throw new InvalidEnumArgumentException("Can not delete a questionnaire when the status is not Concept.");

        _dataDbContext.Remove(entity);
        await _dataDbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}