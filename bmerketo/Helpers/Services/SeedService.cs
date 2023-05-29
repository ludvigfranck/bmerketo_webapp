using bmerketo.Helpers.Repositories;
using Microsoft.AspNetCore.Identity;

namespace bmerketo.Helpers.Services;

public class SeedService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly TagRepo _tagRepo;

    public SeedService(RoleManager<IdentityRole> roleManager, TagRepo tagRepo)
    {
        _roleManager = roleManager;
        _tagRepo = tagRepo;
    }

    public async Task SeedRoles()
    {
        if (!await _roleManager.RoleExistsAsync("admin"))
            await _roleManager.CreateAsync(new IdentityRole("admin"));

        if (!await _roleManager.RoleExistsAsync("user"))
            await _roleManager.CreateAsync(new IdentityRole("user"));
    }
}
