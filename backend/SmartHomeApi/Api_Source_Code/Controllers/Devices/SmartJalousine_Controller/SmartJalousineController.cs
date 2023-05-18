using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/jalousine")]
public class SmartJalousineController : ControllerBase
{
    private readonly SmartJalousineRepo _repository;

    public SmartJalousineController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.SmartJalousine;
    }


    [HttpGet]
    public IActionResult GetAllSmartJalousines()
    {   
        var jalousines = this._repository.GetAll();   
        return Ok(jalousines);
    }

    [HttpGet("getById")]
    public IActionResult GetSmartJalousineById(Guid id)
    {   
        var smartJalousine = this._repository.GetById(id);
        if(smartJalousine == null)
        {
            return NotFound("Jalousine couldn't be located");
        }
        return Ok(smartJalousine);
    }

    [HttpPost("create")]
    public IActionResult CreateSmartJalousine(SmartJalousine SmartJalousine)
    {   
        var inserted = this._repository.Insert(SmartJalousine);   
        if(!inserted.Item1)
        {
             return NotFound("Make sure to put in the right (existing) id of the account before inserting a Api_Source_Code jalousine");
        }
       
        return Ok(inserted.Item2);
    }
    
   
    [HttpDelete("delete")]
    public IActionResult DeleteSmartJalousine(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }
}
