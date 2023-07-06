using hardware_pos.Application.Contracts;
using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;
using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Application;

public class ItemApplicationService : IApplicationService
{
    private readonly IItemRepository _itemRepository;
    private readonly IQrCodeGenerate _qrCodeGenerate;
    private readonly IUnitOfWork _unitOfWork;

    public ItemApplicationService(IQrCodeGenerate qrCodeGenerate, IItemRepository itemRepository, IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _qrCodeGenerate = qrCodeGenerate;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateItem(CreateItemCommand createItemCommand)
    {
        var item = new Item(createItemCommand.CategoryId, createItemCommand.Name, createItemCommand.Description,
            createItemCommand.SalesPrice, createItemCommand.TaxType, createItemCommand.UnitOfMeasure
        );

        try
        {
            await _itemRepository.Add(item);
            await _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DisableItem(DisableItemCommand disableItemCommand)
    {
        var item = await _itemRepository.Load(disableItemCommand.Id);
        if (item == null)
            throw new ArgumentNullException("not found");
        
        item.DisableItem();
        
        await _itemRepository.Add(item);
        await _unitOfWork.Commit();
    }

    public async Task GenerateQrCode(GenerateQrCodeCommand generateQrCodeCommand)
    {
        var item = await _itemRepository.Load(generateQrCodeCommand.Id);
        if (item == null)
            throw new ArgumentNullException("not found");
        
        item.GenerateQrCode(QrCode.FromIdAndName(generateQrCodeCommand.Id, item.Name.ToString(), _qrCodeGenerate));
        
        await _itemRepository.Add(item);
        await _unitOfWork.Commit();
    }
}