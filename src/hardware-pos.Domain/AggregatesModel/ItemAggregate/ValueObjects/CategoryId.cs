using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class CategoryId : ValueObject
{
    public CategoryId(Guid value) : base(value)
    {
        if (value.Equals(Guid.Empty))
            throw new InvalidOperationException();
        Value = value;
    }
}