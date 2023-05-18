using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/bulb/actuator")]
public class BulbActuatorController : ControllerBase
{
    private readonly BulbActuatorRepo _repository;

    public BulbActuatorController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.BulbActuator;
    }


    [HttpPost("create")]
    public IActionResult CreateActuator(BulbActuator actuator)
    {   
        var inserted = this._repository.Insert(actuator);  
        if(!inserted.Item1){
            return NotFound("Make sure to put in the right (existing) id of the bulb before inserting a Api_Source_Code actuator");
        }
        return Ok(inserted.Item2);
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
            return NotFound("Bulb couldn't be located");
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
    public IActionResult UpdateActuator(BulbActuator actuator)
    {        
        bool isUpdated = this._repository.Update(actuator);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }
    
}
