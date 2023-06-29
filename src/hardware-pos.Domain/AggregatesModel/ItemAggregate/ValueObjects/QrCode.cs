using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Domain.AggregatesModel.ItemAggregate.ValueObjects;

public class QrCode : ValueObject
{
    public static QrCode FromIdAndName(Guid id, string name, IQrCodeGenerate qrCodeGenerate) => new QrCode(id, name, qrCodeGenerate);
    private QrCode(Guid id, string name, IQrCodeGenerate qrCodeGenerate)
    {
        Value = qrCodeGenerate.GenerateCode(id, name);
    }
}