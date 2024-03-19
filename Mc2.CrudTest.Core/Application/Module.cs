using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Core.Application;

public static class Module
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Module).Assembly));
    }
}