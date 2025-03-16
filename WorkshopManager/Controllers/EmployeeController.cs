using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Claims;
using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var result = await _employeeService.GetAll();
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        try
        {
            var result = await _employeeService.GetById(id);
            if(result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch(Exception e )
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (result.IsSucceeded) return NoContent();
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id,EmployeeUpdateDTO employeeUpdateDTO)
    {
        try
        {
            var result = await _employeeService.UpdateEmployee(id,employeeUpdateDTO);
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
