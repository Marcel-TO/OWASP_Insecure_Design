using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartHomeApi.New.Models;

public class Account{
    public int Id{get; private set;}
    public string Role{get;private set;}
    public string UserName{get; private set;}
    public string Password{get; private set;}
    public Account(int id, string role, string userName, string password){
        this.Id = id;
        this.Role = role;
        this.UserName = userName;
        this.Password = password;
    }
}