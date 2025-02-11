using Data.Models.ProjectModel;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(ProjectService projectService) : Controller
{
    private readonly ProjectService _projectService = projectService;

    [HttpPost]

    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {

    }
}

    
