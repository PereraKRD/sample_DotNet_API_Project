using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataSerivce.Repositories.Interfaces;

public interface IAchivementRepository : IGenericRepository<Achievement>
{ 
    Task<Achievement?> GetAchievementByDriverId(Guid driverId);
}