using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("thermostat_actuator")]
public class ThermostatActuator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Actuator_Id{get;set;}

    [Required]
    [MaxLength(50)]
    public string Name{get;set;}

    [Required]
    [MaxLength(20)]
    public string Status{get;set;}

    public int Target_Temperature{get;set;}

    public string Sensor_Id{get;set;}

    [Required]
    public string Therm_Id{get;set;}

    public virtual Thermostat? Thermostat { get; set; }

    public ThermostatActuator(string actuator_Id, string name, string status, int target_Temperature, string sensor_Id, string therm_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_Temperature = target_Temperature;
        this.Sensor_Id = sensor_Id;
        this.Therm_Id = therm_Id;
    }
}