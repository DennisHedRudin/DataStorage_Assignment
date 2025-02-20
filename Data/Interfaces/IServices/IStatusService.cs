using Data.Entities;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Infrastructure.Models;

namespace Data.Interfaces.IServices;

public interface IStatusService : IBaseRepository<StatusTypeEntity>
{
    Task<ResponseResult<StatusTypeEntity?>> GetProjectAsync(int id);

    Task<ResponseResult<IEnumerable<StatusTypeEntity?>>> GetAllAsync();
    
}
