using System.Text;
using hardware_pos.Domain.AggregatesModel.ItemAggregate;

namespace hardware_pos.Tests;

public class FakeQrCodeGenerate : IQrCodeGenerate
{
    public byte[] GenerateCode(Guid id, string name)
    {
        return Encoding.ASCII.GetBytes(id + name);
    }
}