using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using SmartHomeApi.Api_Source_Code.Repositories;
using SmartHomeApi.Api_Source_Code.Repositories.Wrapper;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Controllers;

[ApiController]
[Route("api/log")]
public class LoggedDataController : ControllerBase
{
    private readonly LoggedDataRepo _repository;

    public LoggedDataController(IRepositoryWrapper wrapper)
    {
        this._repository = wrapper.LoggedData;
    }


    [HttpGet]
    public IActionResult GetAllLoggs()
    {   
        var loggedDatas = this._repository.GetAll();   
        return Ok(loggedDatas);
    }

    [HttpGet("getById")]
    public IActionResult GetById(Guid id)
    {   
        var loggedData = this._repository.GetById(id);   
        return Ok(loggedData);
    }

    [HttpGet("getByAccountId")]
    public IActionResult GetByAccountId(Guid id)
    {   
        var loggedDatas = this._repository.GetByAccountId(id);   
        return Ok(loggedDatas);
    }

    [HttpPost("create")]
    public IActionResult CreateLog(LoggedData loggedData)
    {   
        var inserted = this._repository.Insert(loggedData);   
        if(!inserted.Item1)
        {
            return NotFound("Couldn't create/log the data");
        }
        return Ok(inserted.Item2);
    }
   
    [HttpDelete("delete")]
    public IActionResult DeleteLog(Guid id)
    {        
        bool isDeleted = this._repository.Delete(id);   
        if(isDeleted)
        {
            return Ok();
        }
        return NotFound();
    }
}
