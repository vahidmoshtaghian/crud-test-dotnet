using Mc2.CrudTest.Core.Domain.Contract;

namespace Mc2.CrudTest.Presentation.Server.Middlewares;

public class DatabaseInitiatorMiddleware
{
    private readonly RequestDelegate _next;

    public DatabaseInitiatorMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var dbcontext = context.RequestServices.GetRequiredService<IContext>();
        await dbcontext.InitAsync();

        await _next(context);
    }
}

public static class DatabaseInitiatorMiddlewareExtensions
{
    public static void UseDatabaseInitiator(this WebApplication app)
    {
        app.UseMiddleware<DatabaseInitiatorMiddleware>();
    }
}
