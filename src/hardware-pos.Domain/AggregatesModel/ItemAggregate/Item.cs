using hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;
using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate;

public class Item : Entity
{
    public Guid Id { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public QrCode QrCode { get; private set; }
    public int BarcodeNumber { get; private set; }
    public SalesPrice SalesPrice { get; private set; }
    public string TaxType { get; private set; }
    public UnitOfMeasure UnitOfMeasure { get; private set; }
    public State State { get; private set; }
    public Uri Image { get; private set; }
    
    protected Item() { }

    public Item(Guid categoryId, string name, string description, decimal salesPrice, string taxType, string unitOfMeasure)
    {
        Apply(new DomainEvents.ItemEvents.ItemCreated()
        {
            CategoryId = categoryId,
            Description = description,
            Name = name,
            SalesPrice = salesPrice,
            TaxType = taxType,
            UnitOfMeasure = unitOfMeasure
        });
    }

    public void GenerateQrCode(QrCode qrcode)
    {
        Apply(new DomainEvents.ItemEvents.QrCodeGenerated()
        {
            Id = Id,
            QrCode = qrcode
        });
    }

    public void DisableItem()
    {
        Apply(new DomainEvents.ItemEvents.ItemRemoved()
        {
            Id = Id
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
            case DomainEvents.ItemEvents.ItemCreated e:
                Id = Guid.NewGuid();
                CategoryId = new CategoryId(e.CategoryId);
                Name = new Name(e.Name);
                Description = new Description(e.Description);
                SalesPrice = new SalesPrice(e.SalesPrice);
                TaxType = e.TaxType;
                UnitOfMeasure = new UnitOfMeasure(e.UnitOfMeasure);
                State = State.Available;
                break;
            case DomainEvents.ItemEvents.QrCodeGenerated e:
                QrCode = e.QrCode;
                break;
            case DomainEvents.ItemEvents.BarcodeNumberGenerated e:
                BarcodeNumber = e.BarcodeNumber;
                break;
            case DomainEvents.ItemEvents.DescriptionUpdated e:
                Description = new Description(e.Description);
                break;
            case DomainEvents.ItemEvents.SalesPriceUpdated e:
                SalesPrice = new SalesPrice(e.SalesPrice);
                break;
            case DomainEvents.ItemEvents.TaxTypeUpdated e:
                TaxType = e.TaxType;
                break;
            case DomainEvents.ItemEvents.ImageUploaded e:
                Image = e.ImageUrl;
                break;
            case DomainEvents.ItemEvents.ItemRemoved e:
                State = State.Unavailable;
                break;
        }
    }
}

public enum State
{
    Unavailable = 0,
    Available = 1
}