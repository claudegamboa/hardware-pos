namespace hardware_pos.Domain.AggregatesModel.ItemAggregate;

public interface IQrCodeGenerate
{
    byte[] GenerateCode(Guid id, string name);
}