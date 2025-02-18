using Data.Contexts;
using Data.Entities;
using Data.Interfaces.IServices;
using Data.Interfaces.Repositories;
using Data.Repositories;


namespace Data.Services;

public class CustomerContactService(CustomerContactRepository repository, DataContext context )
{
    private readonly CustomerContactRepository _repository = repository;

}

