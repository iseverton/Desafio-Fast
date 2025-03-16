using Microsoft.EntityFrameworkCore;
using WorkshopManager.Api.Data.Context;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.Repositories.Interfaces;

namespace WorkshopManager.Api.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
       return await _dbSet.AnyAsync(e => e.Email == email);
    }

    public async Task<Employee> ValidateCredentialsAsync(string email, string password)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
    }
}

