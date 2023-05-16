using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("thermostats")]
public class Thermostat
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Thermostat_Id{get;set;}

    public Guid Account_Id{get;set;}

    [NotMapped]
    List<ThermostatSensor> Sensors {get;set;}

    [NotMapped]
    List<ThermostatActuator> Acutators {get;set;}
    public Thermostat(Guid thermostat_Id, Guid account_Id)
    {
        this.Thermostat_Id = thermostat_Id;
        this.Account_Id = account_Id;
        this.Sensors = new List<ThermostatSensor>();
        this.Acutators = new List<ThermostatActuator>();
    }
}