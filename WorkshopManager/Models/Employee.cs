using System.Text.Json.Serialization;
using WorkshopManager.Api.Models.Enums;

namespace WorkshopManager.Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ERoles Role { get; set; }

        public ICollection<Workshop>? CreatedWorkshops { get; set; }
        public ICollection<Workshop>? Workshops { get; set; }
    }
}
