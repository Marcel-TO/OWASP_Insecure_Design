using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("light_bulbs")]
public class SmartBulb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Smartbulb_Id{get;set;}

    public Guid Account_Id{get;set;}

    [NotMapped]
    List<BulbSensor> Sensors {get;set;}

    [NotMapped]
    List<BulbActuator> Acutators {get;set;}
    public SmartBulb(Guid smartbulb_Id, Guid account_Id)
    {
        this.Smartbulb_Id = smartbulb_Id;
        this.Account_Id = account_Id;
        this.Sensors = new List<BulbSensor>();
        this.Acutators = new List<BulbActuator>();
    }
}