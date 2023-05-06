namespace SmartHomeApi.Api_Source_Code.Models.SystemModel;
public class Sensor{
    public int Id{get;set;}
    public string Name{get;set;}
    public int Temperature{get;set;}
    public string Status{get;set;}
    public int AccountId{get;set;}
    public Sensor(int id, string name, int temperature, string status, int accountId){
        this.Id = id;
        this.Name = name;
        this.Temperature = temperature;
        this.Status = status;
        this.AccountId = accountId;
    }
}