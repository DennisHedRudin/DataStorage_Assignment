using Data.Contexts;
using Data.Entities;
using Data.Interfaces.Repositories;



namespace Data.Repositories;

public class StatusRepository(DataContext context) : BaseRepository<StatusTypeEntity>(context), IStatusRepository
{

    private readonly DataContext _context = context;

}
