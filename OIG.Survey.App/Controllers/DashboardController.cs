using Microsoft.AspNetCore.Mvc;

namespace OIG_Survey_App.Controllers;

public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}