using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("light_bulbs")]
public class SmartBulb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Smartbulb_Id{get;set;}

    public string Acc_Id{get;set;}

    public virtual Account? Account{get;set;}

    public virtual ICollection<BulbSensor> Sensors {get;set;} 

    public virtual ICollection<BulbActuator> Actuators {get;set;}
    public SmartBulb(string smartbulb_Id, string acc_Id)
    {
        this.Smartbulb_Id = smartbulb_Id;
        this.Acc_Id = acc_Id;
        this.Sensors = new List<BulbSensor>();
        this.Actuators = new List<BulbActuator>();
    }
}