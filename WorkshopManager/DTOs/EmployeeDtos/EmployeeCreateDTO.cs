using WorkshopManager.Api.Models.Enums;

namespace WorkshopManager.Api.DTOs.EmployeeDtos
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ERoles Role { get; set; }
    }
}
