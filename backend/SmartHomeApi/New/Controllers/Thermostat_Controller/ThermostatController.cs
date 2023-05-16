using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThermostatController : ControllerBase
{
    private readonly ThermostatRepo _repository;

    public ThermostatController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.Thermostat;
    }


    [HttpGet]
    public IActionResult GetAllThermostats()
    {   
        var thermostats = this._repository.GetAll();   
        return Ok(thermostats);
    }

    [HttpGet("getById")]
    public IActionResult CreateThermostat(Guid id)
    {   
        var thermostat = this._repository.GetById(id);
        if(thermostat == null)
        {
            return NotFound("Thermostat couldn't be located");
        }
        return Ok(thermostat);
    }

    [HttpPost("create")]
    public IActionResult CreateThermostat(Thermostat thermostat)
    {   
        this._repository.Insert(thermostat);   
        this._repository.Save();
        return Ok();
    }
    
   
    [HttpDelete("delete")]
    public IActionResult DeleteThermostat(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }
}
