using hardware_pos.Domain.SeedWork;
using Raven.Client.Documents.Session;

namespace hardware_pos.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAsyncDocumentSession _asyncDocumentSession;

    public UnitOfWork(IAsyncDocumentSession asyncDocumentSession)
    {
        _asyncDocumentSession = asyncDocumentSession;
    }
    
    public Task Commit()
    {
        return _asyncDocumentSession.SaveChangesAsync();
    }
}