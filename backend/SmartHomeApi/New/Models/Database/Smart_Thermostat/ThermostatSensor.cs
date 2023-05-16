using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("thermostat_sensors")]
public class ThermostatSensor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Sensor_Id{get;set;}
    
    [Required]
    [MaxLength(50)]
    public string Name{get;set;}

    [Required]
    [MaxLength(20)]
    public string Status{get;set;}

    [Required]
    public int Temperature{get;set;}

    public Guid Actuator_Id{get;set;}
    
    [Required]
    public Guid Thermostat_Id{get;set;}
    public ThermostatSensor(Guid sensor_Id, string name, string status, int temperature, Guid actuator_Id, Guid thermostat_Id)
    {
        this.Sensor_Id = sensor_Id;
        this.Name = name;
        this.Status = status;
        this.Temperature = temperature;
        this.Actuator_Id = actuator_Id;
        this.Thermostat_Id = thermostat_Id;
    }
}