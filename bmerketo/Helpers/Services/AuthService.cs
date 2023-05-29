using bmerketo.Helpers.Repositories;
using bmerketo.Models.Entities;
using bmerketo.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo.Helpers.Services;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserProfileRepo _userProfileRepo;
    private readonly SeedService _seedService;

    public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, UserProfileRepo userProfileRepo, SeedService seedService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userProfileRepo = userProfileRepo;
        _seedService = seedService;
    }

    public async Task<bool> SignUpUserAsync(SignUpFormViewModel viewModel)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            IdentityUser identityUser = viewModel;
            await _userManager.CreateAsync(identityUser, viewModel.Password);
            await _userManager.AddToRoleAsync(identityUser, roleName);

            UserProfileEntity userProfileEntity = viewModel;
            userProfileEntity.UserId = identityUser.Id;

            await _userProfileRepo.AddIdentityAsync(userProfileEntity);

            return true;
        }
        catch { return false; }
    }

    public async Task<bool> SignInUserAsync(SignInFormViewModel viewModel)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            return result.Succeeded;
        }
        catch { return false; }
    }

    public async Task<bool> SignOutUserAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);
    }

    public async Task<bool> UserExistsAsync(SignUpFormViewModel viewModel)
    {
        if (await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == viewModel.Email) == null)
            return true;

        return false;
    }
}
