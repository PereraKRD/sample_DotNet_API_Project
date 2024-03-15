using FormulaOne.DataSerivce.Data;
using FormulaOne.DataSerivce.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataSerivce.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ILogger logger, AppDbContext dbContext) : base(logger, dbContext)
    {
    }

    public Task<Achievement> GetAchievementByDriverId(Guid driverId)
    {
        throw new NotImplementedException();
    }
    
    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _dbSet.Where(d => d.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(d => d.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} All function error",typeof(DriverRepository));
            throw;
        }
    }
    
    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var driver = await _dbSet.FirstOrDefaultAsync(d => d.Id == id);
            if (driver == null) return false;
            driver.Status = 0;
            driver.UpdatedDate = DateTime.Now;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Delete function error",typeof(DriverRepository));
            throw;
        }
    }
    public override async Task<bool> Update(Driver entity)
    {
        try
        {
            var driver = await _dbSet.FirstOrDefaultAsync(d => d.Id == entity.Id);
            if (driver == null) return false;
            
            driver.UpdatedDate = DateTime.Now;
            driver.FirstName = entity.FirstName;
            driver.LastName = entity.LastName;
            driver.BirthDate = entity.BirthDate;
            driver.DriverNumber = entity.DriverNumber;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Update function error",typeof(DriverRepository));
            throw;
        }
    }
}