using Data.Contexts;
using Data.Entities;
using Data.Repositories;

namespace Data.Services;

public class UserService(UserRepositories userRepository, DataContext context)
{
    private readonly UserRepositories _userRepository = userRepository;
    private readonly DataContext _context = context;

    public async Task<UserEntity?> GetUserAsync(int id)
    {
        var entity = await _userRepository.GetOneAsync(x => x.Id == id);
        return entity;
    }

    public async Task<IEnumerable<UserEntity?>> GetAllAsync()
    {
        var entities = await _userRepository.GetAllAsync();
        return entities;
    }
}

