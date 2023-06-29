using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.InventoryAggregate;

public class Inventory : Entity, IAggregateRoot
{
    public Guid Id { get; private set; }
    public Guid ItemId { get; private set; }
    public string Location { get; private set; }
    public int Quantity { get; private set; }
    protected override void EnsureValidState()
    {
        throw new NotImplementedException();
    }

    protected override void When(object @event)
    {
        switch (@event)
        {
            case DomainEvents.InventoryEvents.InventoryCreated e:
                Id = e.Id;
                ItemId = e.ItemId;
                Location = e.Location;
                Quantity = e.Quantity;
                break;
        }
    }
}