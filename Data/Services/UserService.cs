using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class UserService(UserRepositories userRepository, DataContext context)
{
    private readonly UserRepositories _userRepositories = userRepository;
    private readonly DataContext _context = context;

    
}

