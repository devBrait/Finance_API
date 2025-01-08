﻿using Finance_Application.Validators;
using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Interfaces;
using Finance_Data.Repositories;

namespace Finance_Application.Services;
public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly TransactionDTOValidator _transactionDTOValidator;
    private readonly IBudgetRepository _budgetRepository;

    public TransactionService(ITransactionRepository transactionRepository, TransactionDTOValidator transactionDTOValidator, 
        IBudgetRepository budgetRepository)
    {
        _transactionRepository = transactionRepository;
        _transactionDTOValidator = transactionDTOValidator;
        _budgetRepository = budgetRepository;
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

        var newTransaction = new TransactionDTO
        {
            id = transaction.id,
            user_id = transaction.user_id,
            category_id = transaction.category_id,
            amount = transaction.amount,
            date = transaction.date,
            description = transaction.description,
            created_at = transaction.created_at,
            update_at = transaction.update_at,
        };

        return newTransaction;
    }

    public async Task<TransactionDTO> AddAsync(TransactionDTO transactionDTO)
    {
        var result = await _transactionDTOValidator.ValidateAsync(transactionDTO);

        if (!result.IsValid)
        {
            throw new Exception(string.Join(" ", result.Errors.Select(e => e.ErrorMessage)));
        }

        int budget = await _budgetRepository.GetByCategoryAsync(transactionDTO.category_id);

        if (transactionDTO.amount > budget || budget == 0)
        {
            throw new Exception("Impossible complete this action, amount is greater than budget or not budget defined to this category.");
        }

        var newTransaction = new Transaction
        {
           user_id = transactionDTO.user_id,
           category_id = transactionDTO.category_id,
           amount = transactionDTO.amount,
           date = transactionDTO.date,
           description = transactionDTO.description,
        };

        _transactionRepository.Add(newTransaction);
        await _transactionRepository.SaveAsync();

        return transactionDTO;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);
        
        _transactionRepository.Delete(transaction);
        await _transactionRepository.SaveAsync();
        return true;
    }
}
