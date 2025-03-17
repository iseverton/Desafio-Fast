using System.Linq.Expressions;
using WorkshopManager.Api.Models;

namespace WorkshopManager.Api.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<bool> EmailExistsAsync(string email);
    public Task<Employee> ValidateCredentialsAsync(string email, string password);
    public Task<Employee> GetEmployeeByIdWithWorkshopsAsync(int id);
}
