using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountRepo _repository;

    public AccountController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.Account;
    }


    [HttpGet]
    public IActionResult GetAllAccounts()
    {   
        var accounts = this._repository.GetAll();   
        return Ok(accounts);
    }

    [HttpPost("create")]
    public IActionResult CreateAccount(Account account)
    {   
        this._repository.Insert(account);   
        return Ok();
    }
   
    [HttpDelete("delete")]
    public IActionResult DeleteAccount(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPost("update")]
    public IActionResult UpdateAccount(Account account)
    {        
        bool isUpdated = this._repository.Update(account);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPost("login")]
    public IActionResult Login(Login login)
    {        
        var isUpdated = this._repository.Login(login);   
        if(isUpdated.Item1)
        {
            return Ok(isUpdated.Item2);
        }
        return NotFound("Account matching to login data not found");
    } 
}
