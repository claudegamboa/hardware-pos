namespace hardware_pos.Domain.SeedWork;

public abstract class Entity
{
    private readonly List<object> _events;
    
    protected Entity() => _events = new List<object>();
    
    protected abstract void EnsureValidState();
    protected abstract void When(object @event);

    protected void Apply(object @event)
    {
        When(@event);
        EnsureValidState();
        _events.Add(@event);
    }
}