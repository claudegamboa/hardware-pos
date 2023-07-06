using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.CategoryAggregate;

public interface ICategoryRepository : IRepository
{
    Task Add(Category item);
    Task<Category> Load(Guid id);
}