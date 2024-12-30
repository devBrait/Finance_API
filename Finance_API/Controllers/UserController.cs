using Finance_Application.Services;
using Finance_Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Finance_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateAsync([FromBody]UserDTO user)
    {
        var newUser = await _userService.CreateAsync(user);
        return StatusCode(201, newUser);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequestDTO requestDTO)
    {
        var user = await _userService.LoginAsync(requestDTO.email, requestDTO.password);
        return Ok(user);
    }
}
