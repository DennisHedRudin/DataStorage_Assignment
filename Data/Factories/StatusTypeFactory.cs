using Data.Entities;
using Data.Models.StatusTypeModel;

namespace Data.Factories;

public class StatusTypeFactory
{
    public static StatusTypeEntity Create(StatusTypeRegistrationForm form)
    {
        return new StatusTypeEntity
        {
            StatusName = form.StatusName,
        };
    }

    public static StatusType Create(StatusTypeEntity entity)
    {
        return new StatusType
        {
            Id = entity.Id,
            StatusName = entity.StatusName,
        };
    }
}
