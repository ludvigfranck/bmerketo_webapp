using bmerketo.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace bmerketo.Models.ViewModels;

public class UserAccountDetailsViewModel
{
    public IdentityUser IdentityUser { get; set; } = null!;
    public UserProfile UserProfile { get; set; } = null!;
    public UpdateAccountFormViewModel Form { get; set; } = null!;
}
