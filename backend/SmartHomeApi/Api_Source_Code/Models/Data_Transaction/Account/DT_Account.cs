using System;

namespace SmartHomeApi.Api_Source_Code.Models;

public class DT_Account
{  
    public Guid Account_Id{get; set;}
    public string Role{get; set;}
    public string UserName{get; set;}
    public string Password{get; set;}
    public DT_Account(Guid account_id, string role, string userName, string password)
    {
        this.Account_Id = account_id;
        this.Role = role;
        this.UserName = userName;
        this.Password = password;
    }
}