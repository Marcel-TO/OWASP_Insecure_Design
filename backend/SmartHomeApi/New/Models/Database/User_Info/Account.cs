
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

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
    public Account(Guid account_Id, string role, string userName, string password){
        this.Account_Id = account_Id;
        this.Role = role;
        this.UserName = userName;
        this.Password = password;
    }
}