using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataSerivce.Repositories.Interfaces;

public interface IDriverRepository : IGenericRepository<Driver>
{
    Task<Achievement> GetAchievementByDriverId(Guid driverId);
}