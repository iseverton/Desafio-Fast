using Microsoft.EntityFrameworkCore;
using WorkshopManager.Api.Data.Context;
using WorkshopManager.Api.Models;
using WorkshopManager.Api.Repositories.Interfaces;

namespace WorkshopManager.Api.Repositories;

public class WorkShopRepository : BaseRepository<Workshop>, IWorkShopRepository
{
    public WorkShopRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Workshop>> GetAllWithEmployeesAsync()
    {
        return await _dbSet
            .Include(w => w.Employees) 
            .AsNoTracking()
            .ToListAsync();
    }
}

