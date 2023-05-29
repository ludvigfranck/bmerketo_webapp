using bmerketo.Helpers.Repositories;
using bmerketo.Models.Dtos;
using bmerketo.Models.Entities;

namespace bmerketo.Helpers.Services;

public class CommentService
{
    private readonly UserCommentRepo _userCommentRepo;

    public CommentService(UserCommentRepo userCommentRepo)
    {
        _userCommentRepo = userCommentRepo;
    }

    public async Task<UserComment> SaveUserCommentAsync(UserComment userComment)
    {
        UserCommentEntity entity = userComment;
        if (entity != null)
            return await _userCommentRepo.AddDataAsync(entity);

        return null!;
    }
}
