
using System.Collections.Generic;
namespace SmartHomeApi.New.Models;

public class DT_Thermostat
{
    public Guid Thermostat_Id{get;set;}

    public Guid Acc_Id{get;set;}

    public virtual ICollection<ThermostatSensor> Sensors {get;set;} 

    public virtual ICollection<ThermostatActuator> Actuators {get;set;}

    public DT_Thermostat(Guid thermostat_Id, Guid acc_Id, List<ThermostatSensor> sensors, List<ThermostatActuator> actuators)
    {
        this.Thermostat_Id = thermostat_Id;
        this.Acc_Id = acc_Id;
        this.Sensors = sensors;
        this.Actuators = actuators;
    }
}