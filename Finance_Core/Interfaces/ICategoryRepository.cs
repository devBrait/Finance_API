﻿using Finance_Core.DTOs;
using Finance_Core.Entities;

namespace Finance_Core.Interfaces;
public interface ICategoryRepository : IRepository<Categories>
{
    Task<IEnumerable<CategoryDTO>> GetAllAsync();
    Task<CategoryDTO> GetByIdAsync(int id);
}
