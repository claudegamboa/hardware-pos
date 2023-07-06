namespace hardware_pos.Domain.SeedWork;

public abstract class Entity
{
    public readonly List<object> Events;
    protected Entity() => Events = new List<object>();
    protected abstract void EnsureValidState();
    protected abstract void When(object @event);
    protected void Apply(object @event)
    {
        When(@event);
        EnsureValidState();
        Events.Add(@event);
    }
}