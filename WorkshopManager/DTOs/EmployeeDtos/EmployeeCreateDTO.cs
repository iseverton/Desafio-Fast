using System.Text.Json.Serialization;
using WorkshopManager.Api.Models.Enums;

namespace WorkshopManager.Api.DTOs.EmployeeDtos
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public ERoles Role { get; set; } = ERoles.Employee;
    }
}
