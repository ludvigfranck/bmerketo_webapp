using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.ViewModels;

public class SignInFormViewModel
{
    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail is required!")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }

    public static implicit operator IdentityUser(SignInFormViewModel viewModel)
    {
        return new IdentityUser
        {
            UserName = viewModel.Email
        };
    }
}
