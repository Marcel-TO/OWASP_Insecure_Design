using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("bulb_actuators")]
public class BulbActuator
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

    public int Target_Brightness{get;set;}

    public Guid Sensor_Id{get;set;}

    [Required]
    public Guid Smartbulb_Id{get;set;}
    public BulbActuator(Guid actuator_Id, string name, string status, int target_Brightness, Guid sensor_Id, Guid smartbulb_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_Brightness = target_Brightness;
        this.Sensor_Id = sensor_Id;
        this.Smartbulb_Id = smartbulb_Id;
    }
}