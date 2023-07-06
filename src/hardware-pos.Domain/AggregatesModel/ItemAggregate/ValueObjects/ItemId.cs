using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class ItemId : ValueObject
{
    public Guid Value { get; }

    public ItemId(Guid id) => Value = id;
    
    public override string ToString() => Value.ToString();
}