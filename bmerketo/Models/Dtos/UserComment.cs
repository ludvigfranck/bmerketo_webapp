using bmerketo.Models.Entities;

namespace bmerketo.Models.Dtos;

public class UserComment
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string Message { get; set; } = null!;
    public bool SaveUser { get; set; } = false;

    public static implicit operator UserCommentEntity(UserComment userComment)
    {
        return new UserCommentEntity
        {
            FullName = userComment.FullName,
            Email = userComment.Email,
            PhoneNumber = userComment.PhoneNumber,
            CompanyName = userComment.CompanyName,
            Message = userComment.Message,
            SaveUser = userComment.SaveUser
        };
    }
}
