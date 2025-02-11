using Data.Entities;
using Data.Models.RolesModel;

namespace Data.Factories;

public class RolesFactory
{
    public static RolesEntity Create(RoleRegistrationForm form)
    {
        return new RolesEntity
        {
            RoleName = form.RoleName,            
        };
    }

    public static Roles Create(RolesEntity entity)
    {
        return new Roles
        {
            Id = entity.Id,
            RoleName = entity.RoleName,
            
        };
    }
}
