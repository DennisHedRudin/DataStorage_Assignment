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

public class ProjectService(ProjectRepository projectRepository, DataContext _context) 
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

    public virtual async Task<ProjectEntity?> UpdateOneAsync(Expression<Func<ProjectEntity, bool>> expression, ProjectEntity updatedEntity)
    {
        await _projectRepository.BeginTransactionAsync();
        if (updatedEntity == null)
            return null!;

        try
        {
            var existingEntity = await _projectRepository.GetOneAsync(expression) ?? null;
            if (existingEntity == null)
                return null!;

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);

            await _projectRepository.AddAsync(updatedEntity);
            await _projectRepository.SaveAsync();
            await _projectRepository.CommitTransactionAsync();
            return existingEntity;
        }
        catch (Exception ex)
        {
            await _projectRepository.RollBackTransactionAsync();
            Debug.WriteLine($"Error creating {nameof(ProjectEntity)} :: {ex.Message}");
            return null!;
        }

    }

    public virtual async Task<bool> DeleteOneAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        await _projectRepository.BeginTransactionAsync();

        if (expression == null)
            return false;
        try
        {
            var existingEntity = await _projectRepository.GetOneAsync(expression);
            if (existingEntity == null)
                return false;

            _projectRepository.Delete(existingEntity);
            
            await _projectRepository.SaveAsync();
            await _projectRepository.CommitTransactionAsync();
           
            return true;
        }
        catch (Exception ex)
        {
            await _projectRepository.RollBackTransactionAsync();
            Debug.WriteLine($"Error deleting {nameof(ProjectEntity)} :: {ex.Message}");
            return false;
        }


    }

    public async Task<ResponseResult<ProjectEntity?>> GetProjectAsync(int id)
    {
        var entity = await _projectRepository.GetOneAsync(x => x.Id == id);
        return new ResponseResult<ProjectEntity?>(true, 201, "Project created successfully", entity);
    }

    public async Task<ResponseResult<IEnumerable<ProjectEntity?>>> GetAllAsync()
    {
        var entities = await _projectRepository.GetAllAsync();        
        return new ResponseResult<IEnumerable<ProjectEntity?>>(true, 200, null, entities);
    }




}

