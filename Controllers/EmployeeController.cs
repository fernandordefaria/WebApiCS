using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCS.Model;
using WebApiCS.ViewModel;

namespace WebApiCS.Controllers;

[ApiController]
[Route("api/v1/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentException();
    }

    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeRepository.Get();
        return Ok(employees);
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Add([FromForm] EmployeeViewModel employeeView)
    {
        var filePath = Path.Combine("Storage", employeeView.Photo.FileName);
        
        using Stream fileStream = new FileStream(filePath, FileMode.Create);
        employeeView.Photo.CopyTo(fileStream);
        
        var employee = new Employee(employeeView.Name, employeeView.Age, filePath);
        _employeeRepository.Add(employee);
        return Ok();
    }

    [Authorize]
    [HttpPost]
    [Route("{id}/download")]
    public IActionResult DownloadPhoto(int id)
    {
        var employee = _employeeRepository.Get(id);

        var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

        return File(dataBytes, "image/png");
    }
}