using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("bulb_sensors")]
public class BulbSensor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Sensor_Id{get;set;}
    
    [Required]
    [MaxLength(50)]
    public string Name{get;set;}

    [Required]
    [MaxLength(20)]
    public string Status{get;set;}

    [Required]
    public int Brightness{get;set;}

    public string Actuator_Id{get;set;}
    
    [Required]
    public string Bulb_Id{get;set;}

    public virtual SmartBulb? SmartBulb { get; set; }
     
    public BulbSensor(string sensor_Id, string name, string status, int brightness, string actuator_Id, string bulb_Id)
    {
        this.Sensor_Id = sensor_Id;
        this.Name = name;
        this.Status = status;
        this.Brightness = brightness;
        this.Actuator_Id = actuator_Id;
        this.Bulb_Id = bulb_Id;
    }
}