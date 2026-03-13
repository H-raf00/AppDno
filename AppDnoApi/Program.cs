using AppDnoApi.Database;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;



namespace AppDnoApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Do i need this if i am using fast endpoints?
        // builder.Services.AddControllers();

        builder.Services.AddFastEndpoints();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<AppDnoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // Idk yet if i need them yet
        //app.UseAuthorization();
        //app.MapControllers();

        app.UseCors("AllowAll");
        app.UseFastEndpoints();
        app.Run();
    }
}
