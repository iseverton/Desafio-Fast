using WorkshopManager.Api.DTOs.EmployeeDtos;
using WorkshopManager.Api.Models;

namespace WorkshopManager.Api.DTOs.WorkShopDTOs;


// Usado 
public class WorkShopResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EventDate { get; set; }
    public int CreatedById { get; set; }
    public ICollection<EmployeeResponseDTO> Employees { get; set; }
}

public class WorkshopEmployeeResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime EventDate { get; set; }
    public int CreatedById { get; set; }
}
