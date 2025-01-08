using Finance_Application.Services;
using Finance_Core.DTOs;
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

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var lstBudgets = await _budgetService.GetAllAsync();
        return Ok(lstBudgets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var budget = await _budgetService.GetByIdAsync(id);
        return Ok(budget);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody]BudgetDTO budgetDTO)
    {
        var newBudget = await _budgetService.AddAsync(budgetDTO);
        return StatusCode(201, newBudget);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] BudgetDTO budgetDTO)
    {
        await _budgetService.UpdateAsync(budgetDTO);
        return Ok(true);
    }
}
