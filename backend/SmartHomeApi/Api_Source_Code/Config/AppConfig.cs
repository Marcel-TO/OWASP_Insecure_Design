
namespace SmartHomeApi.Api_Source_Code.Config;

public static class AppConfig{
   public static void Config(WebApplication  app, string policy){
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors(policy);
    app.UseAuthorization();

    app.MapControllers();
    }
}

