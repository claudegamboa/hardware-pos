namespace hardware_pos.Domain.SeedWork;

public interface IUnitOfWork
{
    Task Commit();
}