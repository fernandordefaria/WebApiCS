using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCS.Model;
using System.ComponentModel.DataAnnotations;

[Table("employee")]
public class Employee
{
    [Key]
    public int id { get; set; }
    public string? name { get; set; }
    public int? age { get; set; }
    public string? photo { get; set; }

    public Employee(){}

    public Employee(string name, int age, string photo)
    {
        this.name = name ?? throw new ArgumentNullException();
        this.age = age;
        this.photo = photo;
    }
}