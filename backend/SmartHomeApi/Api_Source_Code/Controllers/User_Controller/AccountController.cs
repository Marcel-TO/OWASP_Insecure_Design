using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/account")]
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

    [HttpGet]
    public IActionResult GetById(string id)
    {   
        var account = this._repository.GetById(id);   
        return Ok(account);
    }

    [HttpPost("create")]
    public IActionResult CreateAccount(DT_Account account)
    {   
        var inserted = this._repository.Insert(account);   
        if(!inserted.Item1)
        {
            return NotFound("Couldn't create account");
        }
        return Ok(inserted.Item2);
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

    [HttpPut("update")]
    public IActionResult UpdateAccount(DT_Account account)
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
