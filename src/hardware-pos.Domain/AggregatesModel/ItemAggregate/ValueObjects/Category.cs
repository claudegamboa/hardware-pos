using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class Category : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Uri Image { get; private set; }
    public string UnitsOfMeasure { get; private set; }
    protected override void EnsureValidState()
    {
        throw new NotImplementedException();
    }

    protected override void When(object @event)
    {
        switch (@event)
        {
            case ItemAggregate.DomainEvents.CategoryEvents.CategoryCreated e:
                Id = e.Id;
                Name = e.Name;
                Description = e.Description;
                UnitsOfMeasure = e.UnitOfMeasure;
                // Image
                break;
            case ItemAggregate.DomainEvents.CategoryEvents.CategoryNameUpdated e:
                break;
            case ItemAggregate.DomainEvents.CategoryEvents.CategoryDescriptionUpdated e:
                break;
            case ItemAggregate.DomainEvents.CategoryEvents.CategoryUnitOfMeasureUpdated e:
                break;
            case ItemAggregate.DomainEvents.CategoryEvents.CategoryImageUploaded e:
                break;
        }
    }
}