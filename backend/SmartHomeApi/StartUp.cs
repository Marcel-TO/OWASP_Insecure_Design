using SmartHomeApi.Api_Source_Code.Config;

public static class StartUp{

    public static void Run(string[] args)
    { 
        var builder = WebApplication.CreateBuilder(args);

        string policy = "policy";
        string connectionString = "Server=localhost,3306;Database=smart_home_db;User Id=root;Password=password;";

        ServiceConfig.Config(builder.Services, policy, connectionString);
       
        var app = builder.Build();
       
        AppConfig.Config(app,policy);
       
        app.Run();
    }
}