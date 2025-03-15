using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Api.DTOs.WorkShopDTOs;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkShopController : ControllerBase
{
    private readonly IWorkShopService _workShopService;

    public WorkShopController(IWorkShopService workShopService)
    {
        _workShopService = workShopService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _workShopService.GetAll();
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _workShopService.GetById(id);
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkShop(WorkShopCreateDTO workShopCreateDTO)
    {
        try
        {
            var result = await _workShopService.PostWorkShopAsync(workShopCreateDTO);
            if (result.IsSucceeded)
            {
                return CreatedAtAction(nameof(GetById), new { id = result }, result);
            }
            return BadRequest(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkShop(int id)
    {
        try
        {
            var result = await _workShopService.DeleteWorkShop(id);
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkShop(int id, WorkShopUpdateDTO workShopUpdateDTO)
    {
        try
        {
            var result = await _workShopService.UpdateWorkShop(id, workShopUpdateDTO);
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
