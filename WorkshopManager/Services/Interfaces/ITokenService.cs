using WorkshopManager.Api.Models;

namespace WorkshopManager.Api.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}
