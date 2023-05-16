using SmartHomeApi.Api_Source_Code.Config;
using SmartHomeApi.New.Contexts;
using SmartHomeApi.New.Repositories.Wrapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


public static class StartUp{

    public static void Run(string[] args){
        var builder = WebApplication.CreateBuilder(args);
        string policy = "policy";

       var connectionString  = builder.Configuration.GetConnectionString("server=localhost;port=3306;database=smart_home_db;user=root;password=password");
        var cs2 = "Server=localhost,3306;Database=smart_home_db;User Id=root;Password=password;";
        
        
         builder.Services.AddDbContextPool<SHDbContext>(
            options => options.UseMySql(cs2,new MySqlServerVersion(new Version(8, 0, 33))));
         builder.Services.AddMvc();
      
        //builder.Services.AddDbContext<SHDbContext>(x => x.UseSqlServer(),
            //providerOptionSystem.TypeLoadException: Method 'Create' in type 'MySql.Data.EntityFrameworkCore.Query.Internal.MySQLSqlTranslatingExpressionVisitorFactors => providerOptions.EnableRetryOnFailur());
        builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

        ServiceConfig.Config(builder.Services, policy);
       
        var app = builder.Build();
       
        AppConfig.Config(app,policy);
       
        app.Run();
    }
}