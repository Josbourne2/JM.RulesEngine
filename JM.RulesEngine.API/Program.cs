using Newtonsoft.Json;
using JM.RulesEngine.Data;
namespace JM.RulesEngine.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            var connectionString = builder.Configuration.GetConnectionString("CosmosConnectionString");
            
            builder.Services.AddApplicationDbContext(connectionString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<EnableRequestBodyBufferingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
