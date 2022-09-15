using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OIG_Survey_App.Models;
using OIG_Survey_App.ModelValidation;
using OIG.Survey.Domain.Concerns.Questionnaires.Close;
using OIG.Survey.Domain.Concerns.Questionnaires.Create;
using OIG.Survey.Domain.Concerns.Questionnaires.Delete;
using OIG.Survey.Domain.Concerns.Questionnaires.Edit;
using OIG.Survey.Domain.Concerns.Questionnaires.Get;
using OIG.Survey.Domain.Concerns.Questionnaires.GetById;
using OIG.Survey.Domain.Concerns.QuestionnaireStatus;
using OIG.Survey.Domain.Concerns.QuestionnaireStatus.Get;

namespace OIG_Survey_App.Controllers;

public class QuestionnaireController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public QuestionnaireController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var query = new GetQuesionnairesQuery();
        var result = await _mediator.Send(query);
        var model = new QuestionnairesModel { Questionnaires = result };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var query = new GetQuestionnaireByIdQuery(id);
        var result = await _mediator.Send(query);
        
        var getStatusesQuery = new GetQuestionnaireStatusQuery(result.QuestionnaireStatusId);
        var getStatusesResult = await _mediator.Send(getStatusesQuery);
        
        var model = new EditFullQuestionnaireModel
        {
            QuestionnaireModel = new EditQuestionnaireModel    {
                Id = result.Id,
                Name = result.Name,
                StartDate = result.StartDate,
                EndDate = result.EndDate,
                StatusId = result.QuestionnaireStatusId
            },
            StatusModels = _mapper.Map<List<QuestionnaireStatusDto>,List<QuestionnaireStatusModel>>(getStatusesResult),
        };
            
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditQuestionnaire(EditFullQuestionnaireModel model)
    {
        if (ModelState.IsValid)
        {
            var command = _mapper.Map<EditQuestionnaireModel, EditQuestionnaireCommand>(model.QuestionnaireModel);
            var result = await _mediator.Send(command);   
            
            return RedirectToAction("Index");
        }
        
        //TODO: Refactor this out maybe into a viewbag or something but this call is unnecessary
        var getStatusesQuery = new GetQuestionnaireStatusQuery(model.QuestionnaireModel.Id);
        var getStatusesResult = await _mediator.Send(getStatusesQuery);
        model.StatusModels =  _mapper.Map<List<QuestionnaireStatusDto>,List<QuestionnaireStatusModel>>(getStatusesResult);
        
        return View("Edit", model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateQuestionnaireModel model)
    {
        if (ModelState.IsValid)
        {
            var command = _mapper.Map<CreateQuestionnaireModel, CreateQuestionnaireCommand>(model);
            var result = await _mediator.Send(command);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var command = new DeleteQuestionnaireCommand(id);
        var result = await _mediator.Send(command);

        return Ok(id);
    }
    
    [HttpPut]
    public async Task<IActionResult> Close(long id)
    {
        var command = new CloseQuestionnaireCommand(id);
        var result = await _mediator.Send(command);

        return Ok(id);
    }
}