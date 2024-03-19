using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Core.Domain.Contract;

public interface IContext
{
    Task InitAsync();
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken token = default);
}
