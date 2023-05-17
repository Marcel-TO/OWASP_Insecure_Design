using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("jalousines")]
public class SmartJalousine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Jalousine_Id{get;set;}


    public Guid Acc_Id{get;set;}

    public virtual Account? Account{get;set;}

    public virtual ICollection<JalousineSensor> Sensors {get;set;} 

    public virtual ICollection<JalousineActuator> Actuators {get;set;}
    public SmartJalousine(Guid jalousine_Id, Guid acc_Id)
    {
        this.Jalousine_Id = jalousine_Id;
        this.Acc_Id = acc_Id;
        this.Sensors = new List<JalousineSensor>();
        this.Actuators = new List<JalousineActuator>();
    }
}