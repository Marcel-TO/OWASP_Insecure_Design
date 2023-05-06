using Microsoft.AspNetCore.Mvc;
using SmartHomeApi.Api_Source_Code.Repositories.SystemRepo;
using SmartHomeApi.Api_Source_Code.Repositories.UserRepo;
using SmartHomeApi.Api_Source_Code.Models.UserModel;
using SmartHomeApi.Api_Source_Code.Models.SystemModel;
using System.Net;
namespace SmartHomeApi.Api_Source_Code.Controllers.SystemControllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private SensorRepo _repository;


    private readonly ILogger<SensorController> _logger;

    public SensorController(ILogger<SensorController> logger)
    {
        _logger = logger;
        this._repository = new SensorRepo();
    }

   

    [HttpDelete]
    public IActionResult DeleteSensor(int sensorId)
    {   
        bool isDeleted = false;
        isDeleted = this._repository.Delete(sensorId);
         if(isDeleted)
         {
            return Ok("Sensor deleted");
        }
        return NotFound("Sensor not deleted");
    } 

    [HttpPost("insert")]
    public IActionResult InsertSensor(Sensor sensor)
    {   
        var tuple = this._repository.Insert(sensor);
        if(tuple.Item1)
        {
            return Ok("Sensor inserted");
        }
        return NotFound("Sensor not inserted");
    }   
}