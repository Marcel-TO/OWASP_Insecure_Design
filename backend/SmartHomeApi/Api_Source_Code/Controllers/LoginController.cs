using Microsoft.AspNetCore.Mvc;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private AccountRepo _repository;

    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
        this._repository = new AccountRepo();
    }

    [HttpPost]
    public Response<User> Login(Login login)
    {   
      List<User> users = this._repository.GetUserByLogin(login); 
      if(users.Count > 1){
        return new Response<User>(new User("",""),false,"To many users share the same account");
      } 
      if (users.Count < 1){
        return new Response<User>(new User("",""),false,"No user found");
      }   
      return new Response<User>(users[0],true,"Success");
    }
    // Other controller methods not shown.
}