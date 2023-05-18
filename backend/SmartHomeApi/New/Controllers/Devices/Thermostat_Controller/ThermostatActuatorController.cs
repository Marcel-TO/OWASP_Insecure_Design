using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/thermostat/actuator")]
public class ThermostatActuatorController : ControllerBase
{
    private readonly ThermostatActuatorRepo _repository;

    public ThermostatActuatorController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.ThermostatActuator;
    }


    [HttpPost("create")]
    public IActionResult CreateActuator(ThermostatActuator Actuator)
    {   
        bool inserted = this._repository.Insert(Actuator);  
        if(!inserted){
            return NotFound("Make sure to put in the right (existing) id of the thermostat before inserting a new thermostat");
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
        var thermostat = this._repository.GetById(id);
        if(thermostat == null)
        {
            return NotFound("Thermostat couldn't be located");
        }
        return Ok(thermostat);
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
    public IActionResult UpdateActuator(ThermostatActuator Actuator)
    {        
        bool isUpdated = this._repository.Update(Actuator);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }
    
}
