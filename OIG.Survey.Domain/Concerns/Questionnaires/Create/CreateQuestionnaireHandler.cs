using AutoMapper;
using MediatR;
using OIG.Survey.Data.Database;
using QuestionnaireEntity = OIG.Survey.Data.Database.Entities.Questionnaire;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Create;

public class CreateQuestionnaireHandler : IRequestHandler<CreateQuestionnaireCommand, long>
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;

    public CreateQuestionnaireHandler(DataDbContext dataDbContext, IMapper mapper)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateQuestionnaireCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreateQuestionnaireCommand, QuestionnaireEntity>(command);
        entity.StartDate = entity.StartDate.ToUniversalTime();
        entity.EndDate = entity.EndDate.ToUniversalTime();

        // Remains a concept until they finalise capturing questions
        entity.QuestionnaireStatusId = (long)Data.Enums.QuestionnaireStatus.Concept;

        try
        {
            await _dataDbContext.AddAsync(entity, cancellationToken);
            await _dataDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return entity.Id;
    }
}