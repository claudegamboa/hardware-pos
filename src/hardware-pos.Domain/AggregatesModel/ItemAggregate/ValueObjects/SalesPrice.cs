using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class SalesPrice : ValueObject
{
    public SalesPrice(decimal value) : base(value)
    {
        if (value < 0 )
            throw new InvalidOperationException();

        Value = value;
    }
}