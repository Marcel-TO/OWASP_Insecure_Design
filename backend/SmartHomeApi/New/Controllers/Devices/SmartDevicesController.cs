using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using System.Net;
using SmartHomeApi.New.Repositories;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

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
