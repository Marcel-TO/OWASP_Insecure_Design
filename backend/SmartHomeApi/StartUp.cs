using Microsoft.EntityFrameworkCore;
using SmartHomeApi.Api_Source_Code.Config;
using SmartHomeApi.New.Contexts;
using SmartHomeApi.New.Repositories.Wrapper;
public static class StartUp{

    public static void Run(string[] args){
        var builder = WebApplication.CreateBuilder(args);
        string policy = "policy";
        //var connectionString  = builder.Configuration.GetConnectionString("DefaultConnection");
        //builder.Services.AddDbContext<SHDbContext>(x => x.UseSqlServer(connectionString));
        //builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        ServiceConfig.Config(builder.Services, policy);
       
        var app = builder.Build();
       
        AppConfig.Config(app,policy);
       
        app.Run();
    }
}