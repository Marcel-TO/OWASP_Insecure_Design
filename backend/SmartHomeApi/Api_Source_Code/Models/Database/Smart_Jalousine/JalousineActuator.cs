using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("jalousine_actuators")]
public class JalousineActuator
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

    public int Target_State{get;set;}

    public string Sensor_Id{get;set;}

    [Required]
    public string Jal_Id{get;set;}

    public virtual SmartJalousine? SmartJalousine { get; set; }

    public JalousineActuator(string actuator_Id, string name, string status, int target_State, string sensor_Id, string jal_Id)
    {
        this.Actuator_Id = actuator_Id;
        this.Name = name;
        this.Status = status;
        this.Target_State = target_State;
        this.Sensor_Id = sensor_Id;
        this.Jal_Id = jal_Id;
    }
}