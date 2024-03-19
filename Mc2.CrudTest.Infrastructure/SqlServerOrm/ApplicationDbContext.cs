using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.SqlServerOrm;

public class ApplicationDbContext : DbContext, IContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasIndex(p => new { p.FirsName, p.LastName, p.PhoneNumber })
            .IsUnique();
        modelBuilder.Entity<Customer>()
            .HasIndex(p => p.Email)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }

    public async Task InitAsync()
    {
        await Database.MigrateAsync();
    }
}
