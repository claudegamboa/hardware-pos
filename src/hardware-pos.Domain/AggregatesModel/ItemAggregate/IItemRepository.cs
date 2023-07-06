using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate;

public interface IItemRepository : IRepository
{
    Task Add(Item item);
    Task<Item> Load(Guid id);
}