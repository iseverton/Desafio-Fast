using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Claims;
using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Controllers;

public class EmployeeController : BaseController
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
            return NotFound(result);
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
            return NotFound(result);
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
            return NotFound(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

  
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
