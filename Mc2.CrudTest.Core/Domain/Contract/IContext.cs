using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.CrudTest.Core.Domain.Contract;

public interface IContext
{
    Task InitAsync();
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken token = default);
    EntityEntry Add(object enttiy);
    EntityEntry Update(object enttiy);
}
