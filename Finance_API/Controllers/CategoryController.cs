using Finance_Application.Services;
using Finance_Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var lstCategories = await _categoryService.GetAllAsync();
        return Ok(lstCategories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CategoryDTO categoryDTO)
    {
        var category = await _categoryService.CreateAsync(categoryDTO);
        return StatusCode(201, category);
    }
}
