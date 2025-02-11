using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Factories;
using Data.Interfaces.Repositories;
using Data.Models.ProjectModel;
using Data.Models.UserModel;
using Data.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class ProjectService(ProjectRepository projectRepository) 
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task<ResponseResult<ProjectEntity>> CreateProjectAsync(ProjectRegistrationForm form)
    {
        await _projectRepository.BeginTransactionAsync();

        if (form == null)
            return new ResponseResult<ProjectEntity>(false, 400, "Form is null", null);

        try
        {
            
            var projectEntity = await _projectRepository.GetOneAsync(x => x.Title == form.Title);
            if (projectEntity != null)
                return new ResponseResult<ProjectEntity>(false, 409, "Project already exists.", null);

            
            projectEntity = ProjectFactory.Create(form);

            
            await _projectRepository.AddAsync(projectEntity);
            await _projectRepository.GetOneAsync(x => x.Id == projectEntity.Id);

            // Om projektet finns, skapa användare och returnera
            if (projectEntity != null)
            {
                var project = ProjectFactory.Create(projectEntity);
                return new ResponseResult<ProjectEntity>(true, 201, null, projectEntity);
            }

            return new ResponseResult<ProjectEntity>(false, 500, "Something went wrong", null);
        }
        catch
        {
            await _projectRepository.RollBackTransactionAsync();
            return new ResponseResult<ProjectEntity>(false, 500, "An error occurred", null);
        }
    }

    


}

