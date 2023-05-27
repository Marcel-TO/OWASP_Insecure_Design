
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("logs")]
public class LoggedData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Log_Id{get; set;}
    public string Data{get;set;}
    public Guid Acc_Id{get;set;}
    public virtual Account? Account{get;set;}
    
    public LoggedData(Guid log_Id, Guid acc_Id, string data){
        this.Log_Id = log_Id;
        this.Acc_Id = acc_Id;
        this.Data = data;
    }   
}