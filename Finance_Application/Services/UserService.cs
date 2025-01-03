using Finance_Application.Validators;
using Finance_Core.DTOs;
using Finance_Core.Entities;
using Finance_Core.Interfaces;

namespace Finance_Application.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly SecurityService _securityService;
    private readonly UserDTOValidator _userDTOValidator;

    public UserService(IUserRepository userRepository, SecurityService securityService, UserDTOValidator userDTOValidator)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _userDTOValidator = userDTOValidator;
    }

    public async Task<UserDTO> CreateAsync(UserDTO user)
    {
        var result = await _userDTOValidator.ValidateAsync(user);

        if (!result.IsValid)
        {
            throw new Exception(string.Join(" ",result.Errors.Select(e => e.ErrorMessage)));
        }

        var userExists = await _userRepository.GetByEmailAsync(user.email);

        if (userExists != null)
        {
            throw new Exception("An account with this email address already exists. Please use a different email.");
        }

        var hash = _securityService.HashPassword(user.password);

        var newUser = new User
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

    public async Task<UserDTO> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
        {
            throw new Exception("An account with this email address not exists. Please use a different email.");
        }

        if (!_securityService.VerifyPassword(password, user.password))
        {
            throw new Exception("Invalid password.");
        }

        return user;
    }
}
