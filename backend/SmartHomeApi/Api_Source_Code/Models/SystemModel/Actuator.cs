namespace SmartHomeApi.Api_Source_Code.Models.SystemModel;
public class Actuator{
    public int Id{get;set;}
    public string Name{get;set;}
    public int TargetTemperature{get;set;}
    public int AccountId{get;set;}
    public Actuator(int id, string name, int targetTemperature, int accountId){
        this.Id = id;
        this.Name = name;
        this.TargetTemperature = targetTemperature;
        this.AccountId = accountId;
    }
}