using Finance_Core.DTOs;
using Finance_Core.Entities;

namespace Finance_Core.Interfaces;

public interface IUserRepository : IRepository<Users>
{
    Task<UserDTO> GetByEmailAsync(string email);
}
