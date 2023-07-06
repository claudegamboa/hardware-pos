namespace hardware_pos.Domain.AggregatesModel.CategoryAggregate;

public class DomainEvents
{
    public class CategoryCreated
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryImageUploaded
    {
        public Guid Id { get; set; }
        public Uri ImageUrl { get; set; }
    }
}