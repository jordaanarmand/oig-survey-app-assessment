using Microsoft.AspNetCore.Mvc;

namespace OIG_Survey_App.Controllers;

public class SurveyController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult Edit()
    {
        return View();
    }
}