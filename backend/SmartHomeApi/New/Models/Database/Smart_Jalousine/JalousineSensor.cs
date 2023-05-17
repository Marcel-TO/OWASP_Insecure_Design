using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("jalousine_sensors")]
public class JalousineSensor
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
    public int State{get;set;}

    public Guid Actuator_Id{get;set;}
    
    [Required]
    public Guid Jal_Id{get;set;}

    public virtual SmartJalousine? SmartJalousine { get; set; }

    public JalousineSensor(Guid sensor_Id, string name, string status, int state, Guid actuator_Id, Guid jal_Id)
    {
        this.Sensor_Id = sensor_Id;
        this.Name = name;
        this.Status = status;
        this.State = state;
        this.Actuator_Id = actuator_Id;
        this.Jal_Id = jal_Id;
    }
}