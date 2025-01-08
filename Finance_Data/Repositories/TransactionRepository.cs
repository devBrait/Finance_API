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

    public async Task<TransactionDTO> GetByIdAsync(int id)
    {
        var transaction = await _context.Transaction
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
            }).Where(x => x.id == id)
            .FirstOrDefaultAsync();

        if (transaction is null)
        {
            return null;
        }

        return transaction;
    }
}
