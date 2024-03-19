using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Infrastructure.SqlServerOrm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure;

public static class Module
{
    public static void AddApplicationSqlServer(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<IContext, ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
}