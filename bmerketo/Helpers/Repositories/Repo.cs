using bmerketo.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo.Helpers.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
    private readonly IdentityContext _identityContext;
    private readonly DataContext _dataContext;

    protected Repo(IdentityContext identityContext, DataContext dataContext)
    {
        _identityContext = identityContext;
        _dataContext = dataContext;
    }

    public virtual async Task<TEntity> AddIdentityAsync(TEntity entity)
    {
        try
        {
            _identityContext.Set<TEntity>().Add(entity);
            await _identityContext.SaveChangesAsync();
            return entity;
        }
        catch { return null!; }
    }

    public virtual async Task<TEntity> AddDataAsync(TEntity entity)
    {
        try
        {
            _dataContext.Set<TEntity>().Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> AddIdentityRangeAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            _identityContext.Set<TEntity>().AddRange(entities);
            await _identityContext.SaveChangesAsync();
            return entities;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> AddDataRangeAsync(IEnumerable<TEntity> entities)
    {
        try
        {
            _dataContext.Set<TEntity>().AddRange(entities);
            await _dataContext.SaveChangesAsync();
            return entities;
        }
        catch { return null!; }
    }

    public virtual async Task<TEntity> GetIdentityAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var item = await _identityContext.Set<TEntity>().FirstOrDefaultAsync(expression);
            return item!;
        }
        catch { return null!; }
    }

    public virtual async Task<TEntity> GetDataAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var item = await _dataContext.Set<TEntity>().FirstOrDefaultAsync(expression);
            return item!;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllIdentityAsync()
    {
        try
        {
            var items = await _identityContext.Set<TEntity>().ToListAsync();
            return items!;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllIdentityAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var items = await _identityContext.Set<TEntity>().Where(expression).ToListAsync();
            return items!;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllDataAsync()
    {
        try
        {
            var items = await _dataContext.Set<TEntity>().ToListAsync();
            return items!;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllDataAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var items = await _dataContext.Set<TEntity>().Where(expression).ToListAsync();
            return items!;
        }
        catch { return null!; }
    }

    public virtual async Task<TEntity> UpdateIdentityAsync(TEntity entity)
    {
        try
        {
            _identityContext.Set<TEntity>().Update(entity);
            await _identityContext.SaveChangesAsync();
            return entity;
        }
        catch { return null!; }
    }

    public virtual async Task<TEntity> UpdateDataAsync(TEntity entity)
    {
        try
        {
            _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        catch { return null!; }
    }

    public virtual async Task<bool> DeleteIdentityAsync(TEntity entity)
    {
        try
        {
            _identityContext.Set<TEntity>().Remove(entity);
            await _identityContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public virtual async Task<bool> DeleteDataAsync(TEntity entity)
    {
        try
        {
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }
}
