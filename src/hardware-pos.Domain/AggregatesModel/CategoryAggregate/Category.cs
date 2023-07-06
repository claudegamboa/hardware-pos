using hardware_pos.Domain.AggregatesModel.CategoryAggregate.ValueObject;
using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.CategoryAggregate;

public class Category : Entity
{
    public string Id { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public string Name { get; private set; }
    public Uri ImageUrl { get; private set; }

    public Category(string name)
    {
        Apply(new DomainEvents.CategoryCreated()
        {
            Id = Guid.NewGuid(),
            Name = name
        });
    }

    public void UploadCategoryImage(Guid id, Uri photoUrl)
    {
        Apply(new DomainEvents.CategoryImageUploaded()
        {
            Id = id,
            ImageUrl = photoUrl
        });
    }
    
    protected override void EnsureValidState()
    {
    }

    protected override void When(object @event)
    {
        switch (@event)
        {
            case DomainEvents.CategoryCreated e:
                Id = e.Id.ToString();
                CategoryId = new CategoryId(e.Id);
                Name = e.Name;
                break;
            case DomainEvents.CategoryImageUploaded e:
                ImageUrl = e.ImageUrl;
                break;
        }
    }
}