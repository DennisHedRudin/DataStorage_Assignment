using Data.Entities;
using Data.Factories;
using Data.Interfaces.IServices;
using Data.Models.ProjectModel;
using Data.Services;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.Controllers;

[Route("api/project")]
[ApiController]
public class ProjectController(ProjectService projectService) : Controller
{
    private readonly ProjectService _projectService = projectService;

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

        return Ok(project.Result);
    }

    
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseResult<object>>> DeleteProject(int id)
    {
        var success = await _projectService.DeleteOneAsync(x => x.Id == id);

        if (!success)
        {
            return NotFound(new ResponseResult<object>(false, 404, "Project not found", null));
        }

        return Ok(new ResponseResult<object>(true, 200, "Project deleted successfully", null));
    }

    
    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseResult<ProjectEntity>>> UpdateProject(int id, ProjectRegistrationForm form)
    {
        var existingProject = await _projectService.GetProjectAsync(id);

        if (existingProject == null)
        {
            return NotFound(new ResponseResult<ProjectEntity>(false, 404, "Project not found", null));
        }
        
        var updatedProject = await _projectService.UpdateOneAsync(x => x.Id == id, ProjectFactory.Create(form));

        if (updatedProject == null)
        {
            return BadRequest(new ResponseResult<ProjectEntity>(false, 400, "Failed to update project", null));
        }

        return Ok(new ResponseResult<ProjectEntity>(true, 200, "Project updated successfully", updatedProject));
    }
}

    
