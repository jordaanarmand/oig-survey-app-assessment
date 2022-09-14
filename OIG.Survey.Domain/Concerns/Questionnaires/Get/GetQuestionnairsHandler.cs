using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OIG.Survey.Data.Database;

namespace OIG.Survey.Domain.Concerns.Questionnaires.Get;

public class GetQuestionnaires : IRequestHandler<GetQuesionnairesQuery, IQueryable<QuestionnaireDto>>
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;

    public GetQuestionnaires(DataDbContext dataDbContext, IMapper mapper)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
    }

    public Task<IQueryable<QuestionnaireDto>> Handle(GetQuesionnairesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataDbContext.Set<Data.Database.Entities.Questionnaire>()
            .AsNoTracking()
            .ProjectTo<QuestionnaireDto>(_mapper.ConfigurationProvider));
    }
}