using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/devices/byUserId")]
public class SmartDevicesController : ControllerBase
{
    private readonly SmartDevicesRepo _repository;

    public SmartDevicesController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.SmartDevices;
    }


   [HttpGet("getById")]
    public IActionResult GetDevicesById(Guid id)
    {   
        var devices = this._repository.GetDevicesById(id);
        if(devices == null)
        {
            return NotFound("Devices couldn't be located");
        }
        return Ok(devices);
    }
}
