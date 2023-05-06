using SmartHomeApi.Api_Source_Code.Repositories;
using Microsoft.EntityFrameworkCore;
namespace SmartHomeApi.Api_Source_Code.Config;

public static class ServiceConfig{

    public static void Config(IServiceCollection services, string policy){
        services.AddCors(p => p.AddPolicy(policy, builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }
        ));
       
        services.AddControllers();  
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}