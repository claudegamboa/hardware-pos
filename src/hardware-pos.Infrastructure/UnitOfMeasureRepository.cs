using hardware_pos.Domain.AggregatesModel.ItemAggregate;
using hardware_pos.Domain.AggregatesModel.UnitOfMeasureAggregate;
using hardware_pos.Domain.SeedWork;
using Raven.Client.Documents.Session;

namespace hardware_pos.Infrastructure;

public class UnitOfMeasureRepository : IUnitOfMeasureRepository, IDisposable
{
    private readonly IAsyncDocumentSession _asyncDocumentSession;

    public UnitOfMeasureRepository(IAsyncDocumentSession asyncDocumentSession)
    {
        _asyncDocumentSession = asyncDocumentSession;
    }
    
    public Task Add(UnitOfMeasure unitOfMeasure)
    {
        var task = _asyncDocumentSession.StoreAsync(unitOfMeasure, EntityId(unitOfMeasure));
        
        Console.WriteLine(_asyncDocumentSession.Advanced.HasChanges);

        return task;
    }

    public Task<UnitOfMeasure> Load(Guid id)
    {
        return _asyncDocumentSession.LoadAsync<UnitOfMeasure>(id.ToString());
    }
    
    private static string EntityId(UnitOfMeasure id) => $"UnitOfMeasure/{id.Id}";

    public void Dispose() => _asyncDocumentSession.Dispose();
}