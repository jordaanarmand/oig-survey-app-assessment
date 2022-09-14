using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OIG_Survey_App.Models;
using OIG.Survey.Domain.Concerns.Questionnaires.Create;
using OIG.Survey.Domain.Concerns.Questionnaires.Delete;
using OIG.Survey.Domain.Concerns.Questionnaires.Get;

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

    [HttpPut]
    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateQuestionnaireModel createQuestionnaireModel)
    {
        if (ModelState.IsValid)
        {
            var command = _mapper.Map<CreateQuestionnaireModel, CreateQuestionnaireCommand>(createQuestionnaireModel);
            var result = await _mediator.Send(command);

            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var command = new DeleteQuestionnaireCommand(id);
        var result = await _mediator.Send(command);

        return Ok(id);
    }
}