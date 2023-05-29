using bmerketo.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.ViewModels;

public class ContactUsFormViewModel
{

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required!")]
    public string FullName { get; set; } = null!;

    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "E-mail Address is required!")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number (Optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company (Optional)")]
    public string? CompanyName { get; set; }

    [Display(Name = "Message")]
    [Required(ErrorMessage = "Message is required!")]
    public string Message { get; set; } = null!;

    public bool SaveUser { get; set; } = false;

    public static implicit operator UserComment(ContactUsFormViewModel viewModel)
    {
        return new UserComment
        {
            FullName = viewModel.FullName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            CompanyName = viewModel.CompanyName,
            Message = viewModel.Message,
            SaveUser = viewModel.SaveUser
        };
    }
}
