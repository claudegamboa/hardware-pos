using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class Description : ValueObject
{
    public Description(string value) : base(value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException();

        Value = value;
    }
}