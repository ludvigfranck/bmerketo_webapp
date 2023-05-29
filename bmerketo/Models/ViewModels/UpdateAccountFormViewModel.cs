using bmerketo.Models.Dtos;
using bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.ViewModels;

public class UpdateAccountFormViewModel
{
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }


    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last Name is required!")]
    public string? LastName { get; set; }


    [Display(Name = "Street Name")]
    public string? StreetName { get; set; }


    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }


    [Display(Name = "City")]
    [Required(ErrorMessage = "City is required!")]
    public string? City { get; set; }


    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }


    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail is not valid")]
    public string? Email { get; set; }


    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+~`\-={}[\]:;""'<>,.?/])[^\s]{8,20}$", ErrorMessage = "Password is invalid")]
    public string? Password { get; set; }


    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
    public string? ConfirmPassword { get; set; }



    public static implicit operator IdentityUser(UpdateAccountFormViewModel viewModel)
    {
        return new IdentityUser
        {
            UserName = viewModel.Email,
            Email = viewModel.Email,
        };
    }

    public static implicit operator UserProfile(UpdateAccountFormViewModel viewModel)
    {
        return new UserProfile
        {
            FirstName = viewModel.FirstName!,
            LastName = viewModel.LastName!,
            StreetName = viewModel.StreetName!,
            PostalCode = viewModel.PostalCode!,
            City = viewModel.City!,
            PhoneNumber = viewModel.PhoneNumber,
            CompanyName = viewModel.CompanyName
        };
    }
}
