using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("thermostat_sensors")]
public class ThermostatSensor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
    public Guid Therm_Id{get;set;}

    public virtual Thermostat? Thermostat { get; set; }

    public ThermostatSensor(Guid sensor_Id, string name, string status, int temperature, Guid actuator_Id, Guid therm_Id)
    {
        this.Sensor_Id = sensor_Id;
        this.Name = name;
        this.Status = status;
        this.Temperature = temperature;
        this.Actuator_Id = actuator_Id;
        this.Therm_Id = therm_Id;
    }
}