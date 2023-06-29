namespace hardware_pos.Domain.AggregatesModel.InventoryAggregate;

public static class DomainEvents
{
    public static class InventoryEvents
    {
        public class InventoryCreated
        {
            public Guid Id { get; set; }
            public Guid ItemId { get; set; }
            public string Location { get; set; }
            public int Quantity { get; set; }
        }
    }
}