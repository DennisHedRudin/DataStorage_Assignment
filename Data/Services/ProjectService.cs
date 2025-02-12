using System.Diagnostics;
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

public class ProjectService(ProjectRepository projectRepository, DataContext _context) : IProjectRepository
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
            await _projectRepository.SaveAsync();

            await _projectRepository.CommitTransactionAsync();

            projectEntity = await _projectRepository.GetOneAsync(x => x.Id == projectEntity.Id);

            if (projectEntity != null)
            {
                
                return new ResponseResult<ProjectEntity>(true, 201, "Project created successfully", projectEntity);
            }
            else
            {
                
                return new ResponseResult<ProjectEntity>(false, 500, "Something went wrong", null);
            }
            
        }
        catch (Exception ex)
        {
            await _projectRepository.RollBackTransactionAsync();
            return new ResponseResult<ProjectEntity>(false, 500, "An error occurred: " + ex.Message, null);
        }
    }

    public virtual async Task<ProjectEntity> UpdateOneAsync(Expression<Func<ProjectEntity, bool>> expression, ProjectEntity updatedEntity)
    {
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await _dbset.FirstOrDefaultAsync(expression) ?? null!;
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return updatedEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating {nameof(ProjectEntity)} :: {ex.Message}");
            return null!;
        }

    }

    public virtual async Task<bool> DeleteOneAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        if (expression == null)
            return false;
        try
        {
            var existingEntity = await _dbset.FirstOrDefaultAsync(expression) ?? null!;
            if (existingEntity == null)
                return false;

            _dbset.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting {nameof(ProjectEntity)} :: {ex.Message}");
            return false;
        }


    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var entity = await _projectRepository.GetOneAsync(x => x.Id == id);
        return ProjectFactory.Create(entity!);
    }




}

