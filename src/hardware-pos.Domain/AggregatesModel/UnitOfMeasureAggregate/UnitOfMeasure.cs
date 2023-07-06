using hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate.ValueObject;
using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate;

public class UnitOfMeasure : Entity
{
    public string Id { get; private set; }
    
    public UnitOfMeasureId UnitOfMeasureId { get; private set; }
    
    public string Description { get; private set; }
    
    public string Type { get; private set; }

    public UnitOfMeasure(string type, string description)
    {
        Apply(new DomainEvents.UnitOfMeasureCreated()
        {
            Id = Guid.NewGuid(),
            Type = type,
            Description = description
        });
    }
    
    protected override void EnsureValidState()
    {
        //throw new NotImplementedException();
    }

    protected override void When(object @event)
    {
        switch (@event)
        {
            case DomainEvents.UnitOfMeasureCreated e:
                Id = e.Id.ToString();
                UnitOfMeasureId = new UnitOfMeasureId(e.Id);
                Type = e.Type;
                Description = e.Description;
                break;
        }
    }
}