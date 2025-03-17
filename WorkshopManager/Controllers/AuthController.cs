using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Api.DTOs.AuthDTOs;
using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.Services;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IEmployeeService _employeeService;

    public AuthController(IAuthService authService, IEmployeeService employeeService)
    {
        _authService = authService;
        _employeeService = employeeService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(EmployeeCreateDTO employeeCreateDTO)
    {
        try
        {
            var result = await _employeeService.PostEmployeeAsync(employeeCreateDTO);
            if (result.IsSucceeded)
            {
                return CreatedAtAction(nameof(Register), new { id = result }, result);
            }
            return BadRequest(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
      var token =  await _authService.Login(loginDTO);
        if (token.IsSucceeded) return Ok(token);
        return BadRequest(token);
    }
}
