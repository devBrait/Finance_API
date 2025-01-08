using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Interfaces;
using Finance_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Repositories;
public class BudgetRepository(DataContext context) : Repository<Budget>(context), IBudgetRepository
{
    public async Task<int> GetAmountAsync(int category_id)
    {
        var amount = await _context.Budget.Where(x => x.category_id == category_id)
            .Select(x => x.amount)
            .FirstOrDefaultAsync();

        return (int)amount;
    }

    public async Task<int> GetByCategoryIdAsync(int category_id)
    {
        var budget_id = await _context.Budget.Where(x => x.category_id == category_id)
            .Select(x => x.id)
            .FirstOrDefaultAsync();

        return budget_id;
    }

    public async Task<IEnumerable<BudgetDTO>> GetAllAsync()
    {
        return await _context.Budget.Select(x => new BudgetDTO
        {
            id = x.id,
            user_id = x.user_id,
            amount = x.amount,
            category_id = x.category_id,
            created_at = x.created_at,
            end_date = x.end_date,
            start_date = x.start_date
        }).ToListAsync();
    }
}
