/*using Microsoft.AspNetCore.Mvc;
using SmartHomeApi.New.Repositories.Wrapper;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Controllers;

[ApiController]
[Route("api/new/[controller]")]
public class LoginController : ControllerBase
{
    private IRepositoryWrapper _repository;

    public LoginController(IRepositoryWrapper repo)
    {
        this._repository = repo;
    }


    [HttpGet]
    public Response<IEnumerable<Account>> GetAllAccounts()
    {   
        var accounts = this._repository.Account.GetAll();
        return new Response<IEnumerable<Account>>(accounts,true,"Success");
    }
    // Other controller methods not shown.
}*/