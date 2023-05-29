using bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo.Helpers.Services;

public class UserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser> GetUserAsync(UserProfileEntity entity)
    {
        var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == entity.UserId);
        if (result != null)
            return result;

        return null!;
    }

    public async Task<IdentityUser> GetUserAsync(ClaimsPrincipal user)
    {
        var result = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == user.Identity!.Name);
        if (result != null)
            return result;

        return null!;
    }

    public async Task<IdentityUser> GetUserAsync(string userId)
    {
        var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (result != null)
            return result;

        return null!;
    }

    public async Task<IList<string>> GetUserRoleAsync(IdentityUser user)
    {
        var result = await _userManager.GetRolesAsync(user);
        if (result != null)
            return result;

        return null!;
    }

    public async Task ChangeUserRoleAsync(string roleName, IdentityUser user)
    {
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, roleName);
    }
}
