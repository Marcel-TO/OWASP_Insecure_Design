using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/jalousine/sensor")]
public class JalousineSensorController : ControllerBase
{
    private readonly JalousineSensorRepo _repository;

    public JalousineSensorController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.JalousineSensor;
    }


    [HttpPost("create")]
    public IActionResult CreateSensor(JalousineSensor sensor)
    {   
        bool inserted = this._repository.Insert(sensor);  
        if(!inserted){
            return NotFound("Make sure to put in the right (existing) id of the jalousine before inserting a new sensor");
        }
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllSensors()
    {   
         var sensors = this._repository.GetAll();   
        return Ok(sensors);
    }

   [HttpGet("getById")]
    public IActionResult GetSensorById(Guid id)
    {   
        var sensor = this._repository.GetById(id);
        if(sensor == null)
        {
            return NotFound("Jalousine couldn't be located");
        }
        return Ok(sensor);
    }

    
    [HttpDelete("delete")]
    public IActionResult DeleteSensor(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPut("update")]
    public IActionResult UpdateSensor(JalousineSensor sensor)
    {        
        bool isUpdated = this._repository.Update(sensor);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }
    
}
