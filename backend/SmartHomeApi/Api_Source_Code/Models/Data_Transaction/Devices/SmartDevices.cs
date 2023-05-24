namespace SmartHomeApi.Api_Source_Code.Models;

public class SmartDevices{
    public List<Thermostat> Thermostats{get;set;}
    public List<SmartBulb> SmartBulbs{get;set;}
    public List<SmartJalousine> SmartJalousines{get;set;}
    public SmartDevices(List<Thermostat> thermostats, List<SmartBulb> smartBulbs, List<SmartJalousine> smartJalousines){
        this.Thermostats = thermostats;
        this.SmartBulbs = smartBulbs;
        this.SmartJalousines = smartJalousines;
    }
}