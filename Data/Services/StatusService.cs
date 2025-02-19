
using Data.Contexts;
using Data.Repositories;

namespace Data.Services;

public class StatusService(StatusRepository statusRepository, DataContext context)
{
    private readonly StatusRepository _projectRepository = statusRepository;
    private readonly DataContext _context = context;


}

