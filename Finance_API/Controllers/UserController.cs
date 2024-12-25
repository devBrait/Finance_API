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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]UserDTO user)
    {
        try
        {
            var newUser = await _userService.CreateAsync(user);
            return StatusCode(201, newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
