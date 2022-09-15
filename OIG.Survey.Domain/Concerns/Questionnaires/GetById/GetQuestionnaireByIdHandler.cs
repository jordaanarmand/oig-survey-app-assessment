using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OIG.Survey.Data.Database;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Domain.Concerns.Questionnaires.GetById;

public class GetQuestionnaireByIdHandler : IRequestHandler<GetQuestionnaireByIdQuery, QuestionnaireDto>
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;

    public GetQuestionnaireByIdHandler(DataDbContext dataDbContext, IMapper mapper)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
    }

    public async Task<QuestionnaireDto> Handle(GetQuestionnaireByIdQuery query, CancellationToken cancellationToken)
    {
        var dto = await _dataDbContext.Set<Questionnaire>()
            .AsNoTracking()
            .Select(_ => new QuestionnaireDto
            {
                Id = _.Id,
                Name = _.Name,
                EndDate = _.EndDate,
                StartDate = _.StartDate,
                QuestionnaireStatusId = _.QuestionnaireStatusId
            })
            .FirstOrDefaultAsync(_ => _.Id == query.Id, cancellationToken: cancellationToken);

        if (dto is null)
        {
            throw new KeyNotFoundException("Unable to find questionnaire with id: " + query.Id);
        }

        return dto;
    }
}