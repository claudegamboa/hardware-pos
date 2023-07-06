using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.SeedWork;
using Raven.Client.Documents.Session;

namespace hardware_pos.Infrastructure;

public class ItemRepository : IItemRepository, IDisposable
{
    private readonly IAsyncDocumentSession _asyncDocumentSession;

    public ItemRepository(IAsyncDocumentSession asyncDocumentSession)
    {
        _asyncDocumentSession = asyncDocumentSession;
    }
    
    public Task Add(Item item)
    {
        return _asyncDocumentSession.StoreAsync(item, EntityId(item));
    }

    public Task<Item> Load(Guid id)
    {
        return _asyncDocumentSession.LoadAsync<Item>(id.ToString());
    }
    
    private static string EntityId(Item id) => $"Item/{id.Id}";

    public void Dispose() => _asyncDocumentSession.Dispose();
}