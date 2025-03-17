using WorkshopManager.Api.DTOs.WorkShopDTOs;
using WorkshopManager.Api.Models.Enums;

namespace WorkshopManager.Api.DTOs.EmployeeDtos;

public class EmployeeResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ERoles Role { get; set; }
}

public class EmployeeWorkshopResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ERoles Role { get; set; }
    public ICollection<WorkshopEmployeeResponseDTO>? Workshops { get; set; }
}