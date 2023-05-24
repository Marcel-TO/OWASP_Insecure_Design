using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/bulb/sensor")]
public class BulbSensorController : ControllerBase
{
    private readonly BulbSensorRepo _repository;

    public BulbSensorController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.BulbSensor;
    }


    [HttpPost("create")]
    public IActionResult CreateSensor(BulbSensor sensor)
    {   
        var inserted = this._repository.Insert(sensor);  
        if(!inserted.Item1){
            return NotFound("Make sure to put in the right (existing) id of the bulb before inserting a Api_Source_Code sensor");
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
            return NotFound("Bulb couldn't be located");
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
    public IActionResult UpdateSensor(BulbSensor sensor)
    {        
        bool isUpdated = this._repository.Update(sensor);   
        if(isUpdated)
        {
            return Ok();
        }
        return NotFound();
    }
    
}
