namespace SmartHomeApi.New.Models;

public class DT_ThermostatActuator
{
    public Guid Actuator_Id{get;set;}

    public string Name{get;set;}

    public string Status{get;set;}

    public int Target_Temperature{get;set;}

    public Guid Sensor_Id{get;set;}

    public Guid Therm_Id{get;set;}


    public DT_ThermostatActuator(Guid actuator_Id, string name, string status, int target_Temperature, Guid sensor_Id, Guid therm_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_Temperature = target_Temperature;
        this.Sensor_Id = sensor_Id;
        this.Therm_Id = therm_Id;
    }
}