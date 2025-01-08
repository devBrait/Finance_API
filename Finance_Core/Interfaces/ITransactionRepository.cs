using Finance_Core.DTOs;
using Finance_Core.Entities;

namespace Finance_Core.Interfaces;
public interface ITransactionRepository : IRepository<Transaction>
{
    Task<IEnumerable<TransactionDTO>> GetAllAsync();
    Task<TransactionDTO> GetByIdAsync(int id);
}
