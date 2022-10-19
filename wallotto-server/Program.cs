using wallotto_server.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.ConfigureJWT(builder.Configuration);
        builder.Services.ConfigureSwagger();
        builder.Services.RegisterFilters();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        ServiceLayer.Bootstrapper.RegisterTypes(
            builder.Services,
            builder.Configuration
        );

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}