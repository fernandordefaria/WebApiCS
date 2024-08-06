using Microsoft.AspNetCore.Mvc;
using WebApiCS.Application.Services;
using WebApiCS.Domain.Models;

namespace WebApiCS.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : Controller
{
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        if (username == "faria" && password == "faria")
        {
            var token = TokenServices.GenerateToken(new Employee());
            return Ok(token);
        }

        return BadRequest("Username or Password invalid");
    }
}