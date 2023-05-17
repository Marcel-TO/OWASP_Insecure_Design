
using System.Collections.Generic;
namespace SmartHomeApi.New.Models;

public class DT_ThermostatSensor
{
    public Guid Sensor_Id{get;set;}
    
    public string Name{get;set;}

    public string Status{get;set;}

    public int Temperature{get;set;}

    public Guid Actuator_Id{get;set;}
    
    public Guid Therm_Id{get;set;}

    public DT_ThermostatSensor(Guid sensor_Id, string name, string status, int temperature, Guid actuator_Id, Guid therm_Id)
    {
        this.Sensor_Id = sensor_Id;
        this.Name = name;
        this.Status = status;
        this.Temperature = temperature;
        this.Actuator_Id = actuator_Id;
        this.Therm_Id = therm_Id;
    }
}