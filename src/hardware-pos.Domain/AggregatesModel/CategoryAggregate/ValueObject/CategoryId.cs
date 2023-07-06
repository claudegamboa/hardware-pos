namespace hardware_pos.Domain.AggregatesModel.CategoryAggregate.ValueObject;

public class CategoryId : SeedWork.ValueObject
{
    public Guid Value { get; }

    public CategoryId(Guid id) => Value = id;
    
    public override string ToString() => Value.ToString();
}