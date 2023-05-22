using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("bulb_actuators")]
public class BulbActuator
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

    public int Target_Brightness{get;set;}

    public string Sensor_Id{get;set;}

    [Required]
    public string Bulb_Id{get;set;}

    public virtual SmartBulb? SmartBulb { get; set; }
    public BulbActuator(string actuator_Id, string name, string status, int target_Brightness, string sensor_Id, string bulb_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_Brightness = target_Brightness;
        this.Sensor_Id = sensor_Id;
        this.Bulb_Id = bulb_Id;
    }
}