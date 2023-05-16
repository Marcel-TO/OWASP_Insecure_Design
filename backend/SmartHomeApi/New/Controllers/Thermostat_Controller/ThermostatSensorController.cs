using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/thermostat/sensor")]
public class ThermostatSensorController : ControllerBase
{
    private readonly ThermostatSensorRepo _repository;

    public ThermostatSensorController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.ThermostatSensor;
    }


    [HttpPost("create")]
    public IActionResult CreateSensor(ThermostatSensor sensor)
    {   
        bool inserted = this._repository.Insert(sensor);  
        if(!inserted){
            return NotFound("Make sure to put in the right (existing) id of the thermostat before inserting a new thermostat");
        }
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllSensors()
    {   
         var sensors = this._repository.GetAll();   
        return Ok(sensors);
    }

    
    [HttpPost("delete")]
    public IActionResult DeleteSensor(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPost("update")]
    public IActionResult UpdateSensor(ThermostatSensor sensor)
    {        
        bool isUpdated = this._repository.Update(sensor);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }
    
}
