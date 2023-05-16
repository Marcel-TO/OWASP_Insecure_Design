using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

[Table("jalousines")]
public class SmartJalousine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Jalousine_Id{get;set;}

    public Guid Account_Id{get;set;}

    [NotMapped]
    List<JalousineSensor> Sensors {get;set;}

    [NotMapped]
    List<JalousineActuator> Acutators {get;set;}
    public SmartJalousine(Guid jalousine_Id, Guid account_Id)
    {
        this.Jalousine_Id = jalousine_Id;
        this.Account_Id = account_Id;
        this.Sensors = new List<JalousineSensor>();
        this.Acutators = new List<JalousineActuator>();
    }
}