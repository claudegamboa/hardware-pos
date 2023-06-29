using System.Text;
using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;
using Shouldly;

namespace hardware_pos.Tests;

public class ItemSpec
{
    private static readonly IQrCodeGenerate qrCodeGenerate = new FakeQrCodeGenerate();

    [Fact]
    public void AddItem()
    {
        var categoryId = Guid.NewGuid();
        var name = "Other";
        var description = "Little bits and bobs";
        var salesPrice = 0.00m;
        var taxType = "VAT";
        var unitOfMeasure = "kg";
        
        var item = new Item(categoryId, name, description, salesPrice, taxType, unitOfMeasure);
        
        AssertProperties(item, categoryId, name, description, salesPrice, taxType, State.Available);
    }

    private static void AssertProperties(Item item, Guid categoryId, string name, string description, decimal salesPrice,
        string taxType, State state)
    {
        item.Id.ShouldNotBeSameAs(Guid.Empty);
        item.CategoryId.Value.ShouldBe(categoryId);
        item.Name.Value.ShouldBe(name);
        item.Description.Value.ShouldBe(description);
        item.SalesPrice.Value.ShouldBe(salesPrice);
        item.TaxType.ShouldBe(taxType);
        item.State.ShouldBe(state);
    }

    [Fact]
    public void RemoveItem()
    {
        var categoryId = Guid.NewGuid();
        var name = "Other";
        var description = "Little bits and bobs";
        var salesPrice = 0.00m;
        var taxType = "VAT";
        var unitOfMeasure = "kg";
        
        var item = new Item(categoryId, name, description, salesPrice, taxType, unitOfMeasure);
        item.DisableItem();
        
        AssertProperties(item, categoryId, name, description, salesPrice, taxType, State.Unavailable);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Cannot_AddItem_WithoutName(string name)
    {
        Should.Throw<InvalidOperationException>(() 
            => new Item(Guid.Empty, name, "Little bits and bobs", 0.00m, "VAT", "kg"));
    }
    
    [Fact]
    public void Cannot_AddItem_WithoutCategory()
    {
        Should.Throw<InvalidOperationException>(() =>
            new Item(Guid.Empty, "Other", "Little bits and bobs", 0.00m, "VAT","kg"));
    }

    [Fact]
    public void Cannot_AddItem_WithoutUnitsOfMeasure()
    {
        Should.Throw<InvalidOperationException>(() 
            => new Item(Guid.NewGuid(), "Other", "Little bits and bobs", 0.00m, "VAT", ""));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Cannot_AddItem_WithoutDescription(string description)
    {
        Should.Throw<InvalidOperationException>(() 
            => new Item(Guid.Empty, "Screws", description, 0.00m, "VAT", "kg"));
    }
    
    [Theory]
    [InlineData(-1.25)]
    [InlineData(-25.00)]
    public void Cannot_AddItem_WithoutSalesPrice(decimal salesPrice)
    {
        Should.Throw<InvalidOperationException>(() 
            => new Item(Guid.NewGuid(), "Screws", "Bits and Bobs", salesPrice, "VAT", "kg"));
    }

    [Fact]
    public void Cannot_AddItem_WithoutTaxType()
    {
        Should.Throw<InvalidOperationException>(() 
            => new Item(Guid.Empty, "Screws", "Bits and Bobs", 0.00m, "VAT", "kg"));
    }
    
    [Fact]
    public void GenerateQrCode()
    {
        var categoryId = Guid.NewGuid();
        var name = "Other";
        var description = "Little bits and bobs";
        var salesPrice = 0.00m;
        var taxType = "VAT";
        var unitOfMeasure = "kg";
        
        var item = new Item(categoryId, name, description, salesPrice, taxType, unitOfMeasure);

        var qrCodeArray = Encoding.ASCII.GetBytes(item.Id.ToString() + item.Name.Value);
        
        item.GenerateQrCode(QrCode.FromIdAndName(item.Id, name, qrCodeGenerate));
        
        item.QrCode.Value.ShouldBe(qrCodeArray);
    }

}