using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/thermostat")]
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
    public IActionResult GetThermostatById(Guid id)
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
        bool isInserted = this._repository.Insert(thermostat);   
        if(isInserted == false)
        {
             return NotFound("Make sure to put in the right (existing) id of the account before inserting a Api_Source_Code thermostat");
        }
       
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
