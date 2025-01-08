using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Enums;
using Finance_Core.Interfaces;
using Finance_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Repositories;
public class TransactionRepository(DataContext context) : Repository<Transaction>(context), ITransactionRepository
{
    public async Task<IEnumerable<TransactionDTO>> GetAllAsync()
    {
        return await _context.Transaction
            .Select(x => new TransactionDTO
            {
                id = x.id,
                user_id = x.id,
                amount = x.amount,
                category_id = x.category_id,
                created_at = x.created_at,
                date = x.date,
                description = x.description,
                update_at = x.update_at
            })
            .ToListAsync();
    }
}
