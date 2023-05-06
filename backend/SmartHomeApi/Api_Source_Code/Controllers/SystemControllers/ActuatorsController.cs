using Microsoft.AspNetCore.Mvc;
using SmartHomeApi.Api_Source_Code.Repositories.SystemRepo;
using SmartHomeApi.Api_Source_Code.Models.SystemModel;
using System.Net;
namespace SmartHomeApi.Api_Source_Code.Controllers.SystemControllers;

[ApiController]
[Route("api/[controller]")]
public class ActuatorController : ControllerBase
{
    private ActuatorRepo _repository;

    private readonly ILogger<ActuatorController> _logger;

    public ActuatorController(ILogger<ActuatorController> logger)
    {
        _logger = logger;
        this._repository = new ActuatorRepo();
    }


   [HttpDelete]
    public IActionResult DeleteActuator(int id)
    {   
        bool isDeleted = false;
        isDeleted = this._repository.Delete(id);
         if(isDeleted)
         {
            return Ok("Actuator deleted");
        }
        return NotFound("Actuator not deleted");
    }

     [HttpPost("insert")]
    public IActionResult InsertActuator(Actuator actuator)
    {   
        var tuple = this._repository.Insert(actuator);
        if(tuple.Item1)
        {
            return Ok("Actuator inserted");
        }
        return NotFound("Actuator not inserted");
    }   
   
}