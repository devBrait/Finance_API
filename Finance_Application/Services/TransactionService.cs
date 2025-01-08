using Finance_Core.DTOs;
using Finance_Core.Interfaces;

namespace Finance_Application.Services;
public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<TransactionDTO>> GetAllAsync()
    {
        var lstTransaction = await _transactionRepository.GetAllAsync();

        if (lstTransaction is null)
        {
            throw new Exception("No transactions found");
        }

        return lstTransaction;
    }

    public async Task<TransactionDTO> GetByIdAsync(int id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);

        if (transaction is null)
        {
            throw new Exception("Transaction with this id not found.");
        }

        return transaction;
    }
}
