using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("thermostats")]
public class Thermostat
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Thermostat_Id{get;set;}

    public string Acc_Id{get;set;}

    public virtual Account? Account{get;set;}

    public virtual ICollection<ThermostatSensor> Sensors {get;set;} 

    public virtual ICollection<ThermostatActuator> Actuators {get;set;}

    public Thermostat(string thermostat_Id, string acc_Id)
    {
        this.Thermostat_Id = thermostat_Id;
        this.Acc_Id = acc_Id;
        this.Sensors = new List<ThermostatSensor>();
        this.Actuators = new List<ThermostatActuator>();
    }
}