using Mc2.CrudTest.Infrastructure.SqlServerOrm;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.AcceptanceTests.Drivers;

public class InMemeoryDbContext : ApplicationDbContext
{
    public InMemeoryDbContext() : base(GetOptions())
    {
    }

    private static DbContextOptions<ApplicationDbContext> GetOptions()
    {
        DbContextOptionsBuilder<ApplicationDbContext> builder = new();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        return builder.Options;
    }
}