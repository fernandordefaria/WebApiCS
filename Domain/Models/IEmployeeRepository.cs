using WebApiCS.Domain.DTOs;

namespace WebApiCS.Domain.Models;

public interface IEmployeeRepository
{
    void Add(Employee employee);
    List<EmployeeDTO> Get();
    Employee? Get(int id);
}