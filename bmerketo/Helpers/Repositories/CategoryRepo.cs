using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Helpers.Repositories;

public class CategoryRepo : Repo<CategoryEntity>
{
    public CategoryRepo(IdentityContext identityContext, DataContext dataContext) : base(identityContext, dataContext)
    {
    }
}
