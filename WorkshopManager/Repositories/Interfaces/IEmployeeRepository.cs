using System.Linq.Expressions;
using WorkshopManager.Api.Entities;

namespace WorkshopManager.Api.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<bool> EmailExistsAsync(string email);
}
