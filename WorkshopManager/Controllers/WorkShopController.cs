using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkshopManager.Api.DTOs.WorkShopDTOs;
using WorkshopManager.Api.Services;
using WorkshopManager.Api.Services.Interfaces;

namespace WorkshopManager.Api.Controllers;

public class WorkshopController : BaseController
{
    private readonly IWorkShopService _workShopService;

    public WorkshopController(IWorkShopService workShopService)
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
            var userIdClaim = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _workShopService.PostWorkShopAsync(userIdClaim ,workShopCreateDTO);
            if (result.IsSucceeded)
            {
                return CreatedAtAction(nameof(GetById), new { id = result}, result);
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
            var userIdClaim = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _workShopService.DeleteWorkShop(userIdClaim, id);
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
            // pegar o id do usuario logado
            var userIdClaim = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value);

            var result = await _workShopService.UpdateWorkShop(userIdClaim, id, workShopUpdateDTO);
            if (result.IsSucceeded) return NoContent();
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/join")]
    public async Task<IActionResult> JoinWorkshop(int id)
    {
        var userIdClaim = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value);
        try
        {
            var result = await _workShopService.JoinWorkshop(userIdClaim, id);
            if (result.IsSucceeded) return Ok(result);
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/leave")]
    public async Task<IActionResult> LeaveWorkshop(int id)
    {
        var userIdClaim = int.Parse(User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value);
        try
        {
            var result = await _workShopService.LeaveWorkshop(userIdClaim, id);
            if (result.IsSucceeded) return Ok();
            return BadRequest(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
