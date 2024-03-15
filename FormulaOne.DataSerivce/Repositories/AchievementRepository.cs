using FormulaOne.DataSerivce.Data;
using FormulaOne.DataSerivce.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataSerivce.Repositories;

public class AchievementRepository : GenericRepository<Achievement> , IAchivementRepository
{

    public AchievementRepository(ILogger logger, AppDbContext dbContext) : base(logger, dbContext)
    {
    }
    
    public async Task<Achievement?> GetAchievementByDriverId(Guid driverId)
    {
        try
        {
            var achievement = await _dbSet.FirstOrDefaultAsync(a => a.DriverId == driverId);
            return achievement;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} GetAchievementByDriverId function error",typeof(AchievementRepository));
            throw;
        }
    }
    
    public override async Task<IEnumerable<Achievement>> All()
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
            _logger.LogError(e,"{Repo} All function error",typeof(AchievementRepository));
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
            _logger.LogError(e,"{Repo} Delete function error",typeof(AchievementRepository));
            throw;
        }
    }
    public override async Task<bool> Update(Achievement entity)
    {
        try
        {
            var achievement = await _dbSet.FirstOrDefaultAsync(d => d.Id == entity.Id);
            if (achievement == null) return false;
            
            achievement.UpdatedDate = DateTime.Now;
            achievement.RaceWins = entity.RaceWins;
            achievement.PolePosition = entity.PolePosition;
            achievement.FastestLap = entity.FastestLap;
            achievement.WorldChampionship = entity.WorldChampionship;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} Update function error",typeof(AchievementRepository));
            throw;
        }
    }
}