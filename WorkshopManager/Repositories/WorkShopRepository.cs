using WorkshopManager.Api.Data.Context;
using WorkshopManager.Api.Entities;
using WorkshopManager.Api.Repositories.Interfaces;

namespace WorkshopManager.Api.Repositories;

public class WorkShopRepository : BaseRepository<Workshop>, IWorkShopRepository
{
    public WorkShopRepository(AppDbContext context) : base(context)
    {
    }
}

