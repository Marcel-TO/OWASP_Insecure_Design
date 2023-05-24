using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using SmartHomeApi.Api_Source_Code.Contexts;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
namespace SmartHomeApi.Api_Source_Code.Config;

public static class ServiceConfig{

    public static void Config(IServiceCollection services, string policy, string connectionString)
    {
        services.AddCors(p => p.AddPolicy(policy, builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }
        ));
       
        services.AddControllers();  
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        
        services.AddControllers().AddJsonOptions(options =>
        
        options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
        
        var serviceProvider = services.BuildServiceProvider();

        services.AddDbContextPool<SHDbContext>(
            options => options.UseMySql(connectionString,new MySqlServerVersion(new Version(8, 0, 33))));
        services.AddMvc();
      
        services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
    }
}