using Microsoft.EntityFrameworkCore;
using SmartHomeApi.Api_Source_Code.Config;

public static class StartUp{

    public static void Run(string[] args){
        var builder = WebApplication.CreateBuilder(args);
        string policy = "policy";
       
        ServiceConfig.Config(builder.Services, policy);
       
        var app = builder.Build();
       
        AppConfig.Config(app,policy);
       
        app.Run();
    }
}