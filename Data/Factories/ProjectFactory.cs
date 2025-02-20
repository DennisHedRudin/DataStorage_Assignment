using Data.Entities;
using Data.Models.ProjectModel;

namespace Data.Factories;

public class ProjectFactory
{
    public static ProjectEntity Create(ProjectRegistrationForm form)
    {
        return new ProjectEntity
        {
            Title = form.Title,
            Description = form.Description,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
        };
    }

    public static ProjectEntity Update(ProjectEntity existingEntity, ProjectUpdateForm form)
    {
        
        existingEntity.Title = form.Title;
        existingEntity.Description = form.Description;
        existingEntity.StartDate = form.StartDate;
        existingEntity.EndDate = form.EndDate;

        return existingEntity;
    }

    public static Project Create(ProjectEntity entity)
    {
        return new Project
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            CustomerId = entity.CustomerId,
            StatusId = entity.StatusId,
            UserId = entity.UserId,
            ProductId = entity.ProductId,
        };
    }
}
