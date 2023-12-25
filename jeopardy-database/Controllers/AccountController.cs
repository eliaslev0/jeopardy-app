using System.Text.Json;
using jeopardy.DTO;
using jeopardy.Services;
using Microsoft.AspNetCore.Mvc;

namespace jeopardy.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase   
{
    private AccountService _service;
    public AccountController(AccountService service) {
        _service = service;
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult<string> Login(LoginDTO login) {
        return _service.Login(login); 
    }
}