using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Factories;
using Data.Models.ProjectModel;
using Data.Repositories;


namespace Data.Services;

public class ProjectService(ProjectRepository projectRepository, DataContext _context) 
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        await _projectRepository.BeginTransactionAsync();

        if (form == null)
            return false;

        try
        {

            var projectEntity = await _projectRepository.GetOneAsync(x => x.Title == form.Title);
            if (projectEntity != null)
                return false;


            projectEntity = ProjectFactory.Create(form);


            await _projectRepository.AddAsync(projectEntity);
            await _projectRepository.SaveAsync();

            await _projectRepository.CommitTransactionAsync();

            projectEntity = await _projectRepository.GetOneAsync(x => x.Id == projectEntity.Id);

            if (projectEntity != null)
            {

                return true;
            }
            else
            {

                return false;
            }

        }
        catch (Exception)
        {
            await _projectRepository.RollBackTransactionAsync();
            return false;
        }
        
    }

    public virtual async Task<ProjectEntity?> UpdateOneAsync(Expression<Func<ProjectEntity, bool>> expression, ProjectUpdateForm form)
    {
        await _projectRepository.BeginTransactionAsync();

        if (form == null)
            return null!;

        try
        {
            
            var existingEntity = await _projectRepository.GetOneAsync(expression);
            if (existingEntity == null)
                return null;


            var updatedEntity = ProjectFactory.Update(existingEntity, form);

            
            
            await _projectRepository.Update(updatedEntity);
            await _context.SaveChangesAsync();
            await _projectRepository.CommitTransactionAsync();

            return updatedEntity;
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

            await _projectRepository.Delete(existingEntity);
            
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

    public async Task<ProjectEntity?> GetProjectAsync(int id)
    {
        var entity = await _projectRepository.GetOneAsync(x => x.Id == id);
        return entity;
    }

    public async Task<IEnumerable<ProjectEntity?>> GetAllAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        return entities;
    }




}

