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
            case DomainEvents.CategoryEvents.CategoryCreated e:
                Id = e.Id;
                Name = e.Name;
                Description = e.Description;
                UnitsOfMeasure = e.UnitOfMeasure;
                // Image
                break;
            case DomainEvents.CategoryEvents.CategoryNameUpdated e:
                break;
            case DomainEvents.CategoryEvents.CategoryDescriptionUpdated e:
                break;
            case DomainEvents.CategoryEvents.CategoryUnitOfMeasureUpdated e:
                break;
            case DomainEvents.CategoryEvents.CategoryImageUploaded e:
                break;
        }
    }
}