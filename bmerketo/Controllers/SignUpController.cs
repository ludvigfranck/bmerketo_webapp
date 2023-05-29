using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

public class SignUpController : Controller
{
    private readonly AuthService _authService;

    public SignUpController(AuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SignUpFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.UserExistsAsync(viewModel))
            {
                if (await _authService.SignUpUserAsync(viewModel))
                    return RedirectToAction("index", "signin");

                ModelState.AddModelError("", "Something went wrong...");
            }

            ModelState.AddModelError("", "A user with the same email already exists!");
        }
            
        return View(viewModel);
    }
}
