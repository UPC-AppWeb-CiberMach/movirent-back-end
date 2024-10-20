namespace Infrastructure.Shared.Persistence.EFC.Repositories.Interfaces;

public interface IUnitOfWork
{
    Task CompleteAsync();
}