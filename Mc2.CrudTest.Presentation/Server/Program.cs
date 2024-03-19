using Mc2.CrudTest.Core.Application;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Presentation.Server.MIddlewares;

namespace Mc2.CrudTest.Presentation.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddApplicationSqlServer(builder.Configuration.GetConnectionString("Default"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseDatabaseInitiator();

        app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}