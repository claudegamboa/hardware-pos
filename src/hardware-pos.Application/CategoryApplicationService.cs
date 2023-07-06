using hardware_pos.Application.Contracts;
using hardware_pos.Domain.AggregatesModel.CategoryAggregate;
using hardware_pos.Domain.SeedWork;

namespace hardware_pos.Application;

public class CategoryApplicationService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryApplicationService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCategory(CreateCategoryCommand command)
    {
        var category = new Category(command.Name);

        await _categoryRepository.Add(category);
        await _unitOfWork.Commit();
    }
}