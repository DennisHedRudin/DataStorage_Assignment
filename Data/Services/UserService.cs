using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Interfaces.Repositories;
using Data.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

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

