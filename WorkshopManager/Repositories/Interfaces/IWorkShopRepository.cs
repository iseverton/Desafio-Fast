using WorkshopManager.Api.Models;

namespace WorkshopManager.Api.Repositories.Interfaces;

public interface IWorkShopRepository : IBaseRepository<Workshop>
{
    public Task<IEnumerable<Workshop>> GetAllWithEmployeesAsync();
    public Task<Workshop> GetByIdWithEmployeeAsync(int id);
}
