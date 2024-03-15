namespace FormulaOne.DataSerivce.Repositories.Interfaces;

public interface IUnitofWork
{
    IDriverRepository Drivers { get; }
    IAchivementRepository Achievements { get; }
    
    Task<bool> CompleteAsync();
}