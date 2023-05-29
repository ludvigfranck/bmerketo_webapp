using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Helpers.Repositories;

public class TagRepo : Repo<TagEntity>
{
    public TagRepo(IdentityContext identityContext, DataContext dataContext) : base(identityContext, dataContext)
    {
    }
}
