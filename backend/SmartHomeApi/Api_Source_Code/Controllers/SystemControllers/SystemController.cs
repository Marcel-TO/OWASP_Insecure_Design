using Microsoft.AspNetCore.Mvc;
using SmartHomeApi.Api_Source_Code.Repositories.SystemRepo;
using SmartHomeApi.Api_Source_Code.Models.SystemModel;
using System.Net;
namespace SmartHomeApi.Api_Source_Code.Controllers.SystemControllers;

[ApiController]
[Route("api/[controller]")]
public class SystemController : ControllerBase
{
    private SensorRepo _sensor_repository;
    private ActuatorRepo _actuator_repository;

    private readonly ILogger<SystemController> _logger;

    public SystemController(ILogger<SystemController> logger)
    {
        _logger = logger;
        this._sensor_repository = new SensorRepo();
        this._actuator_repository = new ActuatorRepo();
    }

   


    [HttpGet("singleUser")]
    public IActionResult GetSystems(int accountId)
    {   
        var sensors = this._sensor_repository.GetById(accountId);
        var actuators = this._actuator_repository.GetById(accountId);
        MySystem system = new MySystem(sensors.ToList(),actuators.ToList());
        return Ok(system);
    }
}