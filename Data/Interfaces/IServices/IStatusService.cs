﻿using Data.Entities;
using Data.Interfaces.Repositories;

namespace Data.Interfaces.IServices;

public interface IStatusService : IBaseRepository<StatusTypeEntity>
{
}
