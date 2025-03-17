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

    public async Task<Workshop> GetByIdWithEmployeeAsync(int id)
    {
        return await _context.Workshops
        .Include(w => w.Employees) 
        .FirstOrDefaultAsync(w => w.Id == id);

    }
}

