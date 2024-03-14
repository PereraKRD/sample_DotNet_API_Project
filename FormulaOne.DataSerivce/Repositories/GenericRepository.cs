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
    public Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}