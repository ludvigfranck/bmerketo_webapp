using bmerketo.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.Entities;

public class UserCommentEntity
{
    [Key]
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string Message { get; set; } = null!;
    public bool SaveUser { get; set; } = false;

    public static implicit operator UserComment(UserCommentEntity entity)
    {
        return new UserComment
        {
            FullName = entity.FullName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            CompanyName = entity.CompanyName,
            Message = entity.Message,
            SaveUser = entity.SaveUser,
        };
    }
}
