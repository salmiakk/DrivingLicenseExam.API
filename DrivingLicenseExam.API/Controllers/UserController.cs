using DrivingLicenseExam.Core.DTO;
using DrivingLicenseExam.Core.Services;
using DrivingLicenseExam.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DrivingLicenseExam.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllUsersBasicInfoAsync());
    }

    [HttpPost("Create")]
    public async Task<IActionResult> AddNewUser([FromBody] UserBasicRequestDto dto)
    {
        try
        {
            await _userService.AddNewUserAsync(dto);
        }
        catch (EntityNotFoundException e)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateExisitingUser([FromBody] UserUpdateRequestDto dto)
    {
        try
        {
            await _userService.UpdateExistingUserAsync(dto);

        }
        catch (EntityNotFoundException e)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteExistingUserById([FromQuery] int id)
    {
        try
        {
            await _userService.DeleteExistingUserByIdAsync(id);
        }
        catch (EntityNotFoundException e)
        {
            return BadRequest();
        }
        return NoContent();
    }
}