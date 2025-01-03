﻿using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Data.Context;
using Finance_Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finance_Data.Repositories;
public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
{
    public async Task<UserDTO> GetByEmailAsync(string email)
    {
        var user = await _context.User.Where(x => x.email == email)
            .FirstOrDefaultAsync();

        if (user is null)
        {
            return null;
        }

        var userDTO = new UserDTO
        {
            name = user.name,
            email = user.email,
            password = user.password,
            created_at = user.created_at,
        };

        return userDTO;
    }
}
