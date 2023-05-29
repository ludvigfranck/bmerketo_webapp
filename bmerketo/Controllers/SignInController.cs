using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class SignInController : Controller
{
    private readonly AuthService _authService;

    public SignInController(AuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SignInFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.SignInUserAsync(viewModel))
                return RedirectToAction("index", "home");

            ModelState.AddModelError("", "Wrong password or e-mail!");
        }
      
        return View(viewModel);
    }
}
