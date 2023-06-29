using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using IronBarCode;

namespace hardware_pos.Infrastructure;

public class QrCodeGenerator : IQrCodeGenerate
{
    public byte[] GenerateCode(Guid id, string name)
    {
        GeneratedBarcode myBarcode = BarcodeWriter.CreateBarcode($"{id}-{name}", BarcodeEncoding.Code128);
        var qrImage = myBarcode.BinaryValue;

        return qrImage;
    }
}