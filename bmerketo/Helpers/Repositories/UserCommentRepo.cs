using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Helpers.Repositories;

public class UserCommentRepo : Repo<UserCommentEntity>
{
    public UserCommentRepo(IdentityContext identityContext, DataContext dataContext) : base(identityContext, dataContext)
    {
    }
}
