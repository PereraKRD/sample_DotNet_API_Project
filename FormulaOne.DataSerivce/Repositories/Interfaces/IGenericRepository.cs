namespace FormulaOne.DataSerivce.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class // making interface anonymous
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(Guid id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(Guid id);
}