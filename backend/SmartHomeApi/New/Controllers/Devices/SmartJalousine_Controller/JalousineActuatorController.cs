using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/jalousine/actuator")]
public class JalousineActuatorController : ControllerBase
{
    private readonly JalousineActuatorRepo _repository;

    public JalousineActuatorController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.JalousineActuator;
    }


    [HttpPost("create")]
    public IActionResult CreateActuator(JalousineActuator Actuator)
    {   
        bool inserted = this._repository.Insert(Actuator);  
        if(!inserted){
            return NotFound("Make sure to put in the right (existing) id of the jalousine before inserting a new actuator");
        }
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllActuators()
    {   
         var Actuators = this._repository.GetAll();   
        return Ok(Actuators);
    }

   [HttpGet("getById")]
    public IActionResult GetActuatorById(Guid id)
    {   
        var actuator = this._repository.GetById(id);
        if(actuator == null)
        {
            return NotFound("Jalousine couldn't be located");
        }
        return Ok(actuator);
    }

    
    [HttpDelete("delete")]
    public IActionResult DeleteActuator(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPut("update")]
    public IActionResult UpdateActuator(JalousineActuator Actuator)
    {        
        bool isUpdated = this._repository.Update(Actuator);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }
    
}
