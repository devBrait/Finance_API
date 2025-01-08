using Finance_Core.Entities;
using Finance_Core.Interfaces;
using Finance_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Repositories;
public class BudgetRepository(DataContext context) : Repository<Budget>(context), IBudgetRepository
{
    public async Task<int> GetByCategoryAsync(int categoryId)
    {
        var amount = await _context.Budget.Where(x => x.category_id == categoryId)
            .Select(x => x.amount)
            .FirstOrDefaultAsync();

        return (int)amount;
    }
}
