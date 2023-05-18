using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/bulb")]
public class SmartBulbController : ControllerBase
{
    private readonly SmartBulbRepo _repository;

    public SmartBulbController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.SmartBulb;
    }


    [HttpGet]
    public IActionResult GetAllSmartBulbs()
    {   
        var bulbs = this._repository.GetAll();   
        return Ok(bulbs);
    }

    [HttpGet("getById")]
    public IActionResult GetSmartBulbById(Guid id)
    {   
        var bulb = this._repository.GetById(id);
        if(bulb == null)
        {
            return NotFound("Bulb couldn't be located");
        }
        return Ok(bulb);
    }

    [HttpPost("create")]
    public IActionResult CreateSmartBulb(SmartBulb smartBulb)
    {   
        bool isInserted = this._repository.Insert(smartBulb);   
        if(isInserted == false)
        {
             return NotFound("Make sure to put in the right (existing) id of the account before inserting a new bulb");
        }
       
        return Ok();
    }
    
   
    [HttpDelete("delete")]
    public IActionResult DeleteSmartBulb(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }
}
