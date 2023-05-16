using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("bulb_sensors")]
public class BulbSensor
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
    public int Brightness{get;set;}

    public Guid Actuator_Id{get;set;}
    
    [Required]
    public Guid Smartbulb_Id{get;set;}
    public BulbSensor(Guid sensor_Id, string name, string status, int brightness, Guid actuator_Id, Guid smartbulb_Id)
    {
        this.Sensor_Id = sensor_Id;
        this.Name = name;
        this.Status = status;
        this.Brightness = brightness;
        this.Actuator_Id = actuator_Id;
        this.Smartbulb_Id = smartbulb_Id;
    }
}