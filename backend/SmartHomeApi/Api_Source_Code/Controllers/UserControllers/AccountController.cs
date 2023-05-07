using Microsoft.AspNetCore.Mvc;
using SmartHomeApi.Api_Source_Code.Repositories.SystemRepo;
using SmartHomeApi.Api_Source_Code.Repositories.UserRepo;
using SmartHomeApi.Api_Source_Code.Models.UserModel;
using SmartHomeApi.Api_Source_Code.Models.SystemModel;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
namespace SmartHomeApi.Api_Source_Code.Controllers.UserControllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private AccountRepo _repository;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
        this._repository = new AccountRepo();
    }

    [HttpPost("login")]
    public IActionResult Login(Login login)
    {   
      var tuple = this._repository.Login(login); 
      if(tuple.Item1 == PasswordVerificationResult.Success || tuple.Item1 == PasswordVerificationResult.SuccessRehashNeeded){
        return Ok(tuple.Item2);
      }   
      return NotFound("Uer not found to be logged in as!");
    }

    [HttpPost("create")]
    public IActionResult CreateAccount(Account account)
    {   
        Tuple<bool,int> tuple = this._repository.Insert(account);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllAccounts()
    {   
        var accounts = this._repository.GetAll();
        
        return Ok(accounts);
    }

    [HttpDelete("delete")]
    public IActionResult DeleteAccount(int account_id)
    {   
        var isDeleted = this._repository.Delete(account_id);
        if(isDeleted){
          return Ok("User/Account deleted");
        }
        return NotFound("User/Account not found");
    }
   
}