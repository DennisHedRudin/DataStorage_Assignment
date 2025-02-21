using Data.Entities;
using Data.Factories;
using Data.Interfaces.IServices;
using Data.Models.ProjectModel;
using Data.Services;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(ProjectService projectService,StatusService statusService, CustomerService customerService, ProductService productService, UserService userService) : Controller
{
    private readonly ProjectService _projectService = projectService;
    private readonly CustomerService _customerService = customerService;
    private readonly ProductService _productService = productService;
    private readonly UserService _userService = userService;
    private readonly StatusService _statusService = statusService;

   

    [HttpPost]

    public async Task<bool> Create(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid)
            return false;

        
        var result = await _projectService.CreateProjectAsync(form);
        return true;

    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var project = await _projectService.GetAllAsync();

        if (project == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Project not found", null));
        }

        return Ok(new ResponseResult<object>(true, 200, "Project found successfully", project));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await _projectService.GetProjectAsync(id);

        if (project == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Project not found", null));
        }

        return Ok(new ResponseResult<ProjectEntity>(true, 200, "Project found successfully", project));
    }

    [HttpGet("customers")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerService.GetAllAsync();
        if (customers == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Customer not found", null));
        }
        return Ok(customers);
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();
        if (products == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Product not found", null));
        }
        return Ok(products);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllAsync();
        if (users == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "User not found", null));
        }
        return Ok(users);
    }

    [HttpGet("statuses")]
    public async Task<IActionResult> GetStatuses()

    {
        var statuses = await _statusService.GetAllAsync();  
        if (statuses == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Status not found", null));
        }
        return Ok(statuses);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseResult<object>>> DeleteProject(int id)
    {
        Console.WriteLine($"Deleting project with ID: {id}");
        var success = await _projectService.DeleteOneAsync(x => x.Id == id);

        if (!success)
        {
            return NotFound(new ResponseResult<object>(false, 404, "Project not found", null));
        }

        return Ok(new ResponseResult<object>(true, 200, "Project deleted successfully", null));
    }

    
    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseResult<ProjectEntity>>> UpdateProject(int id, ProjectUpdateForm form)
    {
        var existingProject = await _projectService.GetProjectAsync(id);

        if (existingProject == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Project not found", null));
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(new ResponseResult<ProjectEntity>(false, 400, "Invalid data", null));
        }

        var updatedProject = await _projectService.UpdateOneAsync(x => x.Id == id, form);

        if (updatedProject == null)
        {
            return BadRequest(new ResponseResult<ProjectEntity>(false, 400, "Failed to update project", null));
        }

        return Ok(new ResponseResult<ProjectEntity>(true, 200, "Project updated successfully", updatedProject));
    }
}

    
