using bmerketo.Helpers.Repositories;
using bmerketo.Models.Dtos;
using System.Security.Claims;

namespace bmerketo.Helpers.Services;

public class UserProfileService
{
    private readonly UserProfileRepo _userProfileRepo;
    private readonly UserService _userService;

    public UserProfileService(UserProfileRepo userProfileRepo, UserService userService)
    {
        _userProfileRepo = userProfileRepo;
        _userService = userService;
    }

    public async Task<IEnumerable<UserProfile>> GetAllUsersProfileAsync()
    {
        var items = new List<UserProfile>();

        foreach (var item in await _userProfileRepo.GetAllIdentityAsync())
        {
            var user = await _userService.GetUserAsync(item);
            UserProfile userProfile = item;
            userProfile.Email = user!.UserName!;

            foreach (var role in await _userService.GetUserRoleAsync(user))
                userProfile.RoleName = role;

            items.Add(userProfile);
        }

        return items;
    }

    public async Task<UserProfile> GetUserProfileAsync(string userId)
    {
        var entity = await _userProfileRepo.GetIdentityAsync(x => x.UserId == userId);
        var identityUser = await _userService.GetUserAsync(entity);

        UserProfile userProfile = entity;
        userProfile.Email = identityUser.UserName!;
        foreach (var role in await _userService.GetUserRoleAsync(identityUser))
            userProfile.RoleName = role;

        return userProfile;
    }

    public async Task<UserProfile> GetUserProfileAsync(ClaimsPrincipal user)
    {
        var identityUser = await _userService.GetUserAsync(user);
        var entity = await _userProfileRepo.GetIdentityAsync(x => x.UserId == identityUser.Id);

        UserProfile userProfile = entity;
        userProfile.Email = identityUser.UserName!;

        return userProfile;
    }
}
