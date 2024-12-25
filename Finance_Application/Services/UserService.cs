using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Interfaces;

namespace Finance_Application.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly SecurityService _securityService;

    public UserService(IUserRepository userRepository, SecurityService securityService)
    {
        _userRepository = userRepository;
        _securityService = securityService;
    }

    public async Task<UserDTO> CreateAsync(UserDTO user)
    {
        var userExists = _userRepository.GetByEmailAsync(user.email);

        if (userExists != null)
        {
            throw new Exception("An account with this email address already exists. Please use a different email.");
        }

        var hash = _securityService.HashPassword(user.password);

        var newUser = new Users
        {
            name = user.name,
            email = user.email,
            password = hash,
            created_at = user.created_at
        };
        
        _userRepository.Add(newUser);
        await _userRepository.SaveAsync();

        return user;
    }
}
