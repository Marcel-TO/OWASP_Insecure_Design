using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

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
        var inserted = this._repository.Insert(smartBulb);   
        if(!inserted.Item1)
        {
             return NotFound("Make sure to put in the right (existing) id of the account before inserting a Api_Source_Code bulb");
        }
       
        return Ok(inserted.Item2);
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
