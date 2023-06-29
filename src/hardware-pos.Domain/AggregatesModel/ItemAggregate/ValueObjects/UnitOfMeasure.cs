using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class UnitOfMeasure : ValueObject
{
    public UnitOfMeasure(string value) : base(value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException(value);

        Value = value;
    }
}