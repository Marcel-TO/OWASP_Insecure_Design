using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

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
        bool isInserted = this._repository.Insert(SmartJalousine);   
        if(isInserted == false)
        {
             return NotFound("Make sure to put in the right (existing) id of the account before inserting a new jalousine");
        }
       
        return Ok();
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
