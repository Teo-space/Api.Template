using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Template.Interfaces.DbContexts;


public interface IBaseDbContext
{
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    int SaveChanges();

    int SaveChanges(bool acceptAllChangesOnSuccess);
}
