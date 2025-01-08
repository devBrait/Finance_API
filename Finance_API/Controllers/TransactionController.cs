using Finance_Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{

    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var lstTransactions = await _transactionService.GetAllAsync();
        return Ok(lstTransactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var transacton = await _transactionService.GetByIdAsync(id);
        return Ok(transacton);
    }
}
