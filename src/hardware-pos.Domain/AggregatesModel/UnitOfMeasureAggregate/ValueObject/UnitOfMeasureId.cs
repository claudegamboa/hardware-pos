namespace hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate.ValueObject;

public class UnitOfMeasureId
{
    public Guid Value { get; }

    public UnitOfMeasureId(Guid id) => Value = id;
    
    public override string ToString() => Value.ToString();
}