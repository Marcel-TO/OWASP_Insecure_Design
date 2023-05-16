using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("jalousine_actuators")]
public class JalousineActuator
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

    public int Target_State{get;set;}

    public Guid Sensor_Id{get;set;}

    [Required]
    public Guid Jalousine_Id{get;set;}
    public JalousineActuator(Guid actuator_Id, string name, string status, int target_State, Guid sensor_Id, Guid jalousine_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_State = target_State;
        this.Sensor_Id = sensor_Id;
        this.Jalousine_Id = jalousine_Id;
    }
}