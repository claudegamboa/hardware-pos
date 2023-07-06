using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate;

public interface IUnitOfMeasureRepository : IRepository
{
    Task Add(UnitOfMeasure item);
    Task<UnitOfMeasure> Load(Guid id);
}