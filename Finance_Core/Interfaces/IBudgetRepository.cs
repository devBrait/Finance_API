using Finance_Core.Entities;

namespace Finance_Core.Interfaces;
public interface IBudgetRepository : IRepository<Budget>
{
    Task<int> GetByCategoryAsync(int categoryId);
}
