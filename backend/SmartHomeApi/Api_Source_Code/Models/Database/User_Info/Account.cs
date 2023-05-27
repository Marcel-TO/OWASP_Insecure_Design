
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.Api_Source_Code.Models;

[Table("accounts")]
public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Account_Id{get; set;}

    [Required]
    [MaxLength(20)]
    public string Role{get; set;}

    [Required]
    [MaxLength(40)]
    public string UserName{get; set;}

    [Required]
    [MaxLength(150)]
    public string Password{get; set;}

    public virtual ICollection<Thermostat> Thermostats {get;set;}
    public virtual ICollection<SmartBulb> SmartBulbs {get;set;} 
    public virtual ICollection<SmartJalousine> SmartJalousines {get;set;}  
    public virtual ICollection<LoggedData> LoggedDatas {get;set;}
    public Account(Guid account_Id, string role, string userName, string password){
        this.Account_Id = account_Id;
        this.Role = role;
        this.UserName = userName;
        this.Password = password;
        this.Thermostats = new List<Thermostat>();
        this.SmartBulbs = new List<SmartBulb>();
        this.SmartJalousines = new List<SmartJalousine>();
        this.LoggedDatas = new List<LoggedData>();
    }

    
}