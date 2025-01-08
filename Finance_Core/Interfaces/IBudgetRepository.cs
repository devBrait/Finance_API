using Finance_Core.DTOs;
using Finance_Core.Entities;

namespace Finance_Core.Interfaces;
public interface IBudgetRepository : IRepository<Budget>
{
    Task<int> GetAmountAsync(int category_id);
    Task<IEnumerable<BudgetDTO>> GetAllAsync();
    Task<int> GetByCategoryIdAsync(int category_id);
}
