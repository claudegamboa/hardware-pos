using hardware_pos.Domain.AggregatesModel.CategoryAggregate;
using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.SeedWork;
using Raven.Client.Documents.Session;

namespace hardware_pos.Infrastructure;

public class CategoryRepository : ICategoryRepository, IDisposable
{
    private readonly IAsyncDocumentSession _asyncDocumentSession;

    public CategoryRepository(IAsyncDocumentSession asyncDocumentSession)
    {
        _asyncDocumentSession = asyncDocumentSession;
    }
    
    public Task Add(Category category)
    {
        var task = _asyncDocumentSession.StoreAsync(category, EntityId(category));
        
        Console.WriteLine(_asyncDocumentSession.Advanced.HasChanges);

        return task;
    }

    public Task<Category> Load(Guid id)
    {
        return _asyncDocumentSession.LoadAsync<Category>(id.ToString());
    }
    
    private static string EntityId(Category id) => $"Category/{id.Id}";

    public void Dispose() => _asyncDocumentSession.Dispose();
}