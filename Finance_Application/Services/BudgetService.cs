using Finance_Application.Validators;
using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Finance_Application.Services;
public class BudgetService
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly UpdateBudgetValidator _updateBudgetValidator;
    private readonly AddBudgetValidator _addBudgetValidator;

    public BudgetService(IBudgetRepository budgetRepository, UpdateBudgetValidator updateBudgetValidator
        ,AddBudgetValidator addBudgetValidator)
    {
        _budgetRepository = budgetRepository;
        _updateBudgetValidator = updateBudgetValidator;
        _addBudgetValidator = addBudgetValidator;
    }

    public async Task<IEnumerable<BudgetDTO>> GetAllAsync()
    {
        var lstBudgets = await _budgetRepository.GetAllAsync();
        return lstBudgets;
    }

    public async Task<BudgetDTO> GetByIdAsync(int id)
    {
        var budget = await _budgetRepository.GetByIdAsync(id);

        var budgetDTO = new BudgetDTO
        {
            id = budget.id,
            user_id = budget.user_id,
            category_id = budget.category_id,
            amount = budget.amount,
            created_at = budget.created_at,
            end_date = budget.end_date,
            start_date = budget.start_date
        };

        return budgetDTO;
    }

    public async Task<BudgetDTO> AddAsync(BudgetDTO budgetDTO)
    {
        var result = await _addBudgetValidator.ValidateAsync(budgetDTO);

        if (!result.IsValid)
        {
            throw new Exception(string.Join(" ", result.Errors.Select(e => e.ErrorMessage)));
        }

        int budgetExists = await _budgetRepository.GetAmountAsync(budgetDTO.category_id);

        if (budgetExists != 0)
        {
            throw new Exception("Budget already assigned in this category, update the budget.");
        }

        var newBudget = new Budget
        {
            id = budgetDTO.id,
            user_id = budgetDTO.user_id,
            category_id = budgetDTO.category_id,
            amount = budgetDTO.amount,
            created_at = budgetDTO.created_at,
            end_date = budgetDTO.end_date,
            start_date = budgetDTO.start_date
        };

        _budgetRepository.Add(newBudget);
        await _budgetRepository.SaveAsync();

        return budgetDTO;
    }

    public async Task<bool> UpdateAsync(BudgetDTO budgetDTO)
    {
        var result = await _updateBudgetValidator.ValidateAsync(budgetDTO);

        if (!result.IsValid)
        {
            throw new Exception(string.Join(" ", result.Errors.Select(e => e.ErrorMessage)));
        }

        var budgetExists = await _budgetRepository.GetByIdAsync(budgetDTO.id);

        budgetExists.amount = budgetDTO.amount;
        budgetExists.end_date = budgetDTO.end_date;

        _budgetRepository.Update(budgetExists);
        await _budgetRepository.SaveAsync();

        return true;
    }
}
