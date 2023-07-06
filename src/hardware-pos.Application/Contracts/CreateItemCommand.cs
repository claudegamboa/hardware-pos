namespace hardware_pos.Application.Contracts;

public class CreateItemCommand
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal SalesPrice { get; set; }
    public string TaxType { get; set; }
    public string UnitOfMeasure { get; set; }
}