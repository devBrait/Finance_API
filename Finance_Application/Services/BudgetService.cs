using Finance_Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Finance_Application.Services;
public class BudgetService
{
    private readonly IBudgetRepository _budgetRepository;

    public BudgetService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }
}
