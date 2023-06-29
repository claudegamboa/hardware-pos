namespace hardware_pos.Domain.SeedWork;

public abstract class ValueObject
{
    protected ValueObject(object value)
    {
        Value = value;
    }
    
    internal ValueObject() {}

    public object Value { get; protected set; }
}