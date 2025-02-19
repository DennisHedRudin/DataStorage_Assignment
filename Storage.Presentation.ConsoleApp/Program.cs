

using Data.Contexts;
using Data.Repositories;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
        .AddDbContext<DataContext>(options => options.UseSqlServer(""))
        .AddScoped<ProjectRepository>()
        .AddScoped<ProjectService>()
        .AddScoped<CustomerContactRepository>()
        .AddScoped<CustomerContactService>()
        .AddScoped<CustomerRepository>()
        .AddScoped<CustomerService>()
        .AddScoped<ProductRepository>()
        .AddScoped<ProductService>()
        .AddScoped<RolesRepository>()
        .AddScoped<RolesService>()
        .AddScoped<StatusRepository>()
        .AddScoped<StatusService>()
        .AddScoped<UserRepositories>()
        .AddScoped<UserService>()
        .BuildServiceProvider();

var customerDialogs = services.GetRequiredService<IMenuDialog>();
await customerDialogs.MenuOptions();
