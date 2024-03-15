using FormulaOne.DataSerivce.Data;
using FormulaOne.DataSerivce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataSerivce.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger _logger;
    protected AppDbContext _context;
    internal DbSet<T> _dbSet;
    public GenericRepository(ILogger logger, AppDbContext dbContext)
    {
        this._logger = logger;
        this._context = dbContext;
        
        _dbSet = _context.Set<T>();
    }
    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}