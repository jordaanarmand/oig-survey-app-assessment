using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OIG.Survey.Data.Database;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Edit;

public class EditQuestionnaireHandler : IRequestHandler<EditQuestionnaireCommand, long>
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;

    public EditQuestionnaireHandler(DataDbContext dataDbContext, IMapper mapper)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(EditQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dataDbContext.Set<Questionnaire>()
            .FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);

        if (entity is null) throw new NullReferenceException("A questionnaire with this id could not be found");

        entity.Name = request.Name;
        entity.StartDate = request.StartDate;
        entity.EndDate = request.EndDate;
        entity.QuestionnaireStatusId = request.StatusId;

        await _dataDbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}