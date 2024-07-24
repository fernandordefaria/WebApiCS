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
    private readonly ILogger<EmployeeController> _logger;
    public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentException(nameof(employeeRepository));
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }

    // [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        _logger.Log(LogLevel.Error, "Error: ");

        // throw new Exception("Erro teste");
        
        var employees = _employeeRepository.Get();
        _logger.LogInformation("Teste de Log");
        
        return Ok(employees);
    }
    
    // [Authorize]
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

    // [Authorize]
    [HttpPost]
    [Route("{id}/download")]
    public IActionResult DownloadPhoto(int id)
    {
        var employee = _employeeRepository.Get(id);

        var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

        return File(dataBytes, "image/png");
    }
}