using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("thermostat_actuator")]
public class ThermostatActuator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Actuator_Id{get;set;}

    [Required]
    [MaxLength(50)]
    public string Name{get;set;}

    [Required]
    [MaxLength(20)]
    public string Status{get;set;}

    public int Target_Temperature{get;set;}

    public Guid Sensor_Id{get;set;}

    [Required]
    public Guid Thermostat_Id{get;set;}
    public ThermostatActuator(Guid actuator_Id, string name, string status, int target_Temperature, Guid sensor_Id, Guid thermostat_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_Temperature = target_Temperature;
        this.Sensor_Id = sensor_Id;
        this.Thermostat_Id = thermostat_Id;
    }
}