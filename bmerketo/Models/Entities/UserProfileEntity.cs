using bmerketo.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models.Entities;

public class UserProfileEntity
{
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? PhoneNumber { get; set; } 
    public string? CompanyName { get; set; }
    public IdentityUser User { get; set; } = null!;

    public static implicit operator UserProfile(UserProfileEntity entity)
    {
        return new UserProfile
        {
            UserId = entity.UserId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            StreetName = entity.StreetName,
            PostalCode = entity.PostalCode,
            City = entity.City,
            PhoneNumber = entity.PhoneNumber,
            CompanyName = entity.CompanyName
        };
    } 
}
