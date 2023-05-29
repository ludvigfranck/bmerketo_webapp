using bmerketo.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

[Authorize]
public class SignOutController : Controller
{
    private readonly AuthService _authService;

    public SignOutController(AuthService authService)
    {
        _authService = authService;
    }

    public async Task<IActionResult> Index()
    {
        if (await _authService.SignOutUserAsync(User))
            return RedirectToAction("index", "home");

        return RedirectToAction("Index");
    }
}
