using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

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
        var inserted = this._repository.Insert(sensor);  
        if(!inserted.Item1){
            return NotFound("Make sure to put in the right (existing) id of the jalousine before inserting a Api_Source_Code sensor");
        }
        return Ok(inserted.Item2);
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
