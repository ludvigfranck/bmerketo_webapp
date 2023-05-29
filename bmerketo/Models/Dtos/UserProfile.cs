using bmerketo.Models.Entities;

namespace bmerketo.Models.Dtos;

public class UserProfile
{
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string? CompanyName { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string RoleName { get; set; } = null!;

    public static implicit operator UserProfileEntity(UserProfile userProfile)
    {
        return new UserProfileEntity
        {
            UserId = userProfile.UserId,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            StreetName = userProfile.StreetName,
            PostalCode = userProfile.PostalCode,
            City = userProfile.City
        };
    }
}
