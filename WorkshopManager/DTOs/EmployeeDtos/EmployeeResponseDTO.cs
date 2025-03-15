using WorkshopManager.Api.Models.Enums;

namespace WorkshopManager.Api.DTOs.EmployeeDtos;

public class EmployeeResponseDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ERoles Role { get; set; }
}
