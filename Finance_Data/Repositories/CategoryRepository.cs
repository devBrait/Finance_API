using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Enums;
using Finance_Core.Interfaces;
using Finance_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Repositories;
public class CategoryRepository(DataContext context) : Repository<Categories>(context), ICategoryRepository
{
    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        return await _context.Categories
            .Select(x => new CategoryDTO
            {
                id = x.id,
                name = x.name,
                type = (CategoryEnum)x.type,
                created_at = x.created_at
            })
            .ToListAsync();
    }

    public async Task<CategoryDTO> GetByIdAsync(int id)
    {
        var category = await _context.Categories
            .Select(x => new CategoryDTO
            {
                id = x.id,
                name = x.name,
                type = (CategoryEnum)x.type,
                created_at = x.created_at
            }).Where(x => x.id == id)
            .FirstOrDefaultAsync();

        if (category is null)
        {
            return null;
        }

        return category;
    }
}
