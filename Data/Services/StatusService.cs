
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;

namespace Data.Services;

public class StatusService(DataContext context) : BaseService<StatusTypeEntity>(context), IStatusService
{

    private readonly DataContext _context = context;


}

