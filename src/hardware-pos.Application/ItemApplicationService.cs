using hardware_pos.Domain.AggregatesModel.ItemAggregate;

namespace hardware_pos.Application;

public class ItemApplicationService : IApplicationService
{
    private readonly IQrCodeGenerate _qrCodeGenerate;

    public ItemApplicationService(IQrCodeGenerate qrCodeGenerate)
    {
        _qrCodeGenerate = qrCodeGenerate;
    }
}

public interface IApplicationService
{
}