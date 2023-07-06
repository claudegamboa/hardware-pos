using hardware_pos.Application.Contracts;
using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate;
using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Application;

public class UnitOfMeasureApplicationService : IApplicationService
{
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UnitOfMeasureApplicationService(IUnitOfMeasureRepository unitOfMeasureRepository, IUnitOfWork unitOfWork)
    {
        _unitOfMeasureRepository = unitOfMeasureRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateUnitOfMeasure(CreateUnitOfMeasureCommand command)
    {
        var unitOfMeasure = new UnitOfMeasure(command.Type, command.Description);

        await _unitOfMeasureRepository.Add(unitOfMeasure);
        await _unitOfWork.Commit();
    }
}