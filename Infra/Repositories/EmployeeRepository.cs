using WebApiCS.Domain.Models;
using WebApiCS.Domain.DTOs;

namespace WebApiCS.Infra.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();
    
    public void Add(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public List<EmployeeDTO> Get()
    {
        return _context.Employees.Select(b=>new EmployeeDTO(){Id = b.id, NameEmployee = b.name, Photo = b.photo}).ToList();
    }

    public Employee Get(int id)
    {
        return _context.Employees.Find(id);
    }
}