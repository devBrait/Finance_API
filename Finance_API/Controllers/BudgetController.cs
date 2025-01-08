using Finance_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finance_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly BudgetService _budgetService;

    public BudgetController(BudgetService budgetService)
    {
        _budgetService = budgetService;
    }
}
