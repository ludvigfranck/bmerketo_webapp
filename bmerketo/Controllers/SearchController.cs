using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class SearchController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
