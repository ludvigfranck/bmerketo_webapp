using bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.ViewModels;

public class SignUpFormViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First Name is required!")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last Name is required!")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Street Name")]
    [Required(ErrorMessage = "Street Name is required!")]
    public string StreetName { get; set; } = null!;


    [Display(Name = "Postal Code")]
    [Required(ErrorMessage = "Postal Code is required!")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City")]
    [Required(ErrorMessage = "City is required!")]
    public string City { get; set; } = null!;


    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }


    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail is required!")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+~`\-={}[\]:;""'<>,.?/])[^\s]{8,20}$", ErrorMessage = "Password is invalid")]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirm Password is required!")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
    public string ConfirmPassword { get; set; } = null!;



    public static implicit operator IdentityUser(SignUpFormViewModel viewModel)
    {
        return new IdentityUser
        {
            UserName = viewModel.Email,
            Email = viewModel.Email,
        };
    }

    public static implicit operator UserProfileEntity(SignUpFormViewModel viewModel)
    {
        return new UserProfileEntity
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            StreetName = viewModel.StreetName,
            PostalCode = viewModel.PostalCode,
            City = viewModel.City,
            PhoneNumber = viewModel.PhoneNumber,
            CompanyName = viewModel.CompanyName
        };
    }
}
