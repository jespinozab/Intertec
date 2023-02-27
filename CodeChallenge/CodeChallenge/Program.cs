
using CodeChallenge;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var defaultApiUrl = builder.Configuration.GetValue<string>("ApiEndpoint");

        var service = new Service();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddScoped<IService, Service>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
    

}