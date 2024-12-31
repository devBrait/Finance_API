using Finance_Application.Validators;
using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Interfaces;

namespace Finance_Application.Services;
public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryDTOValidator _categoryDTOValidator;

    public CategoryService(ICategoryRepository categoryRepository, CategoryDTOValidator categoryDTOValidator)
    {
        _categoryRepository = categoryRepository;
        _categoryDTOValidator = categoryDTOValidator;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        var lstCategories = await _categoryRepository.GetAllAsync();

        if (lstCategories is null)
        {
            throw new Exception("No categories found.");
        }

        return lstCategories;
    }

    public async Task<CategoryDTO> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
        {
            throw new Exception("Category with this id not found.");
        }

        return category;
    }

    public async Task<CategoryDTO> CreateAsync(CategoryDTO category)
    {
        var result = await _categoryDTOValidator.ValidateAsync(category);

        if (!result.IsValid)
        {
            throw new Exception(string.Join(" ", result.Errors.Select(e => e.ErrorMessage)));
        }

        var newCategory = new Categories
        {
            name = category.name,
            type = category.type,
            created_at = category.created_at
        };

        _categoryRepository.Add(newCategory);
        await _categoryRepository.SaveAsync();

        return category;
    }
}
