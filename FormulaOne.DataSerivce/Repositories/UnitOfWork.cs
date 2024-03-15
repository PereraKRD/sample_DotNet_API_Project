using FormulaOne.DataSerivce.Data;
using FormulaOne.DataSerivce.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataSerivce.Repositories;

public class UnitOfWork : IUnitofWork , IDisposable
{
    private readonly AppDbContext _context;
    public IDriverRepository Drivers { get; }
    public IAchivementRepository Achievements { get; }
    
    public UnitOfWork(AppDbContext context , ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");
        
        Drivers = new DriverRepository(logger, _context);
        Achievements = new AchievementRepository(logger, _context);
    }
    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}