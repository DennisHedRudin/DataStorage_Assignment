using Data.Contexts;
using Data.Repositories;
using Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Data\\Local_Database.mdf;Integrated Security=True;Connect Timeout=30"));
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<CustomerContactRepository>();
builder.Services.AddScoped<CustomerContactService>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<RolesRepository>();
builder.Services.AddScoped<RolesService>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<UserRepositories>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.Run();
