using bmerketo.Helpers.Services;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers;

[Authorize(Roles = "user")]
public class AccountController : Controller
{
    private readonly UserService _userService;
    private readonly UserProfileService _userProfileService;

    public AccountController(UserService userService, UserProfileService userProfileService)
    {
        _userService = userService;
        _userProfileService = userProfileService;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new UserAccountDetailsViewModel
        {
            UserProfile = await _userProfileService.GetUserProfileAsync(User),
            IdentityUser = await _userService.GetUserAsync(User),
            Form = new UpdateAccountFormViewModel()
        };
        return View(viewModel);
    }
}
