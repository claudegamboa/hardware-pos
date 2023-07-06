namespace hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate;

public class DomainEvents
{
    public class UnitOfMeasureCreated
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}